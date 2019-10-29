using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static QuanLyQuanCafe.fAccount;
using Menu = QuanLyQuanCafe.DTO.Menu;

namespace QuanLyQuanCafe
{
    public partial class fQLTable : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.Type); }
        }

        public fQLTable(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTablelist();
            LoadCategory();
            LoadComBoxtable(cbCban);
        }
        #region Method

        void changeAccount(int Type)
        {
            adminToolStripMenuItem.Enabled = Type == 1 ;
            thôngTinTàiKhoảnToolStripMenuItem.Text += "(" + LoginAccount.TenHienthi + ")";
        }
        void LoadCategory()
        {
            List<Category> listCatrgory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCatrgory;
            cbCategory.DisplayMember = "TenLoai";
        }
        void LoadFoodListByCategoryID(int MaLoai)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(MaLoai);
            cbfood.DataSource = listFood;
            cbfood.DisplayMember = "TenDU";
        }
        void LoadTablelist()
        {
            fpnlTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTablelist();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Tenban + Environment.NewLine + item.TTBan;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.TTBan)
                {
                    case "Trống":
                        btn.BackColor = Color.Blue;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;

                }

                fpnlTable.Controls.Add(btn);
            }
        }

        void ShowBill(int MaBan)
        {
            lstBill.Items.Clear();

            float totalPrice = 0;

            List<Menu> listView = MenuDAO.Instance.GetListMenuByTable(MaBan);

            foreach (Menu item in listView)
            {
                ListViewItem lsvitem = new ListViewItem(item.DinkName.ToString());
                lsvitem.SubItems.Add((item.Count.ToString()));
                lsvitem.SubItems.Add((item.Price.ToString()));
                lsvitem.SubItems.Add((item.TotalPrice.ToString()));

                totalPrice += item.TotalPrice;

                lstBill.Items.Add(lsvitem);

            }

            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = totalPrice.ToString("c", culture);

        }

        void LoadComBoxtable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTablelist();
            cb.DisplayMember = "TenBan";
        }
        #endregion
        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).Maban;
            lstBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.ShowDialog();
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccount f = new fAccount(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }
        void f_UpdateAccount (object sender , AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = " Thông tin tài khoản (" + e.Acc.TenHienthi + ")";
        }
        private void BtnGG_Click(object sender, EventArgs e)
        {
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            int MaLoai = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            MaLoai = selected.MaLoai;

            LoadFoodListByCategoryID(MaLoai);
        }
        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lstBill.Tag as Table;

                int MaHD = BillDAO.Instance.GetUnCheckBillIDTableId(table.Maban);

                string MaDU = (cbfood.SelectedItem as Food).MaDU;

                int count = (int)numFood.Value;

                if (MaHD == -1)
                {
                    BillDAO.Instance.InsertBill(table.Maban);

                    BillinfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), MaDU, count);
                }
                else
                {
                    BillinfoDAO.Instance.InsertBillInfo(MaHD, MaDU, count);
                }

                ShowBill(table.Maban);

                LoadTablelist();
            }
            catch(Exception)
            { }
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {

            Table table = lstBill.Tag as Table;

            int MaHD = BillDAO.Instance.GetUnCheckBillIDTableId(table.Maban);
            int discount = (int)numdiscount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice*1000 - ((totalPrice*1000) / 100) * discount;

            if (MaHD != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1}*1000 - (({1}*1000)/100) x {2} = {3}", table.Tenban, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(MaHD, discount, (float)finalTotalPrice);

                    ShowBill(table.Maban);

                    LoadTablelist();
                }
            }
            else
            {
                MessageBox.Show("Bạn đã thanh toán rồi !!!");
            }
        }
        private void BtnCban_Click(object sender, EventArgs e)
        {
            int id1 = (lstBill.Tag as Table).Maban;

            int id2 = (cbCban.SelectedItem as Table).Maban;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} qua bàn {1}", (lstBill.Tag as Table).Tenban, (cbCban.SelectedItem as Table).Tenban), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {


                TableDAO.Instance.SwitchTable(id1, id2);

                TableDAO.Instance.PooledTable(id1, id2);

                LoadTablelist();

                ShowBill(id2);

            }
            else
            {
                
            }
        }
        #endregion
    }
}
