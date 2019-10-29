using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();

        BindingSource accountlist = new BindingSource();

        BindingSource tablelist = new BindingSource();

        BindingSource categorylist = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            Load();

        }
        #region methos

        List<Food> SeachMenuByName(string TenDU)
        {
            List<Food> listfood = FoodDAO.Instance.SeachMenubyName(TenDU);

            return listfood;
        }
        void Load()
        {
            dtgrvMenu.DataSource = foodList;
            dtgrvAccount.DataSource = accountlist;
            dtgrvTable.DataSource = tablelist;
            dtgrvCategory.DataSource = categorylist;


            LoadlistBillDate(dtpkFromdate.Value);
            LoadlistFood();
            LoadAccount();
            LoadlistTable();
            LoadlistCategory();
            LoadCategoryIntoCombobox(cbfoodCategory);
            AddFood();
            AddAccount();
            AddTable();
            AddCategory();
        }

        void AddAccount()
        {
            txbAccountName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbViewName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "TenHT", true, DataSourceUpdateMode.Never));
            numType.DataBindings.Add(new Binding("Value", dtgrvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetlistAccount();
        }
        void LoadlistBillDate(DateTime ngayTT)
        {
            dtgvBill.DataSource = BillDAO.Instance.GhetBillDate(ngayTT);
        }
        void AddFood()
        {
            txbmenuID.DataBindings.Add(new Binding("Text", dtgrvMenu.DataSource, "MaDU", true, DataSourceUpdateMode.Never));
            txbmenuname.DataBindings.Add(new Binding("Text", dtgrvMenu.DataSource, "TenDU", true, DataSourceUpdateMode.Never));
            nummenuprice.DataBindings.Add(new Binding("Value", dtgrvMenu.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }
        void AddTable()
        {
            txbIDTable.DataBindings.Add(new Binding("Text", dtgrvTable.DataSource, "MaBan", true, DataSourceUpdateMode.Never));
            txbNameTable.DataBindings.Add(new Binding("Text", dtgrvTable.DataSource, "TenBan",true, DataSourceUpdateMode.Never));
            txbStatus.DataBindings.Add(new Binding("Text", dtgrvTable.DataSource, "TTBan", true, DataSourceUpdateMode.Never));
        }
        void AddCategory()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgrvCategory.DataSource, "MaLoai", true, DataSourceUpdateMode.Never));
            txbNameCategory.DataBindings.Add(new Binding("Text", dtgrvCategory.DataSource, "TenLoai", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "TenLoai";
        }
        void LoadlistFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetlistFood();
        }
        void LoadlistTable()
        {
            tablelist.DataSource = TableDAO.Instance.LoadTablelist();
        }
        void LoadlistCategory()
        {
            categorylist.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void Deleteaccount(string Username)
        {
            if (loginAccount.UserName.Equals(Username))
            {
                MessageBox.Show("Bạn không được xóa tài khoản này");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(Username))
            {
                MessageBox.Show("Xóa thành công tài khoản");
            }
            else
            {
                MessageBox.Show("Chưa xóa tài khoản");
            }
            LoadAccount();
        }
        #endregion

        #region events

        private void TabAccout_Click(object sender, EventArgs e)
        {

        }

        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            LoadlistBillDate(dtpkFromdate.Value);
        }

        private void BtnViewDink_Click(object sender, EventArgs e)
        {
            LoadlistFood();
        }

        private void TxbID_TextChanged(object sender, EventArgs e)
        {
            if (dtgrvMenu.SelectedCells.Count > 0)
            {
                int id = (int)dtgrvMenu.SelectedCells[0].OwningRow.Cells["MaLoai"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);
                cbfoodCategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbfoodCategory.Items)
                {
                    if (item.MaLoai == cateogory.MaLoai)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbfoodCategory.SelectedIndex = index;
            }

        }

        private void BtnAddDink_Click(object sender, EventArgs e)
        {
            string MaDU = txbmenuID.Text;
            string TenDU = txbmenuname.Text;
            int MaLoai = (cbfoodCategory.SelectedItem as Category).MaLoai;
            int DonGia = (int)nummenuprice.Value;

            if (FoodDAO.Instance.InserMenu(MaDU, TenDU, MaLoai, DonGia))
            {
                MessageBox.Show("Thêm đồ thành công");
                LoadlistFood();
            }
            else
            {
                MessageBox.Show("Điền lại");
            }
        }

        private void BtnEditDink_Click(object sender, EventArgs e)
        {
            string MaDU = txbmenuID.Text;
            string TenDU = txbmenuname.Text;
            int MaLoai = (cbfoodCategory.SelectedItem as Category).MaLoai;
            int DonGia = (int)nummenuprice.Value;

            if (FoodDAO.Instance.UpdateMenu(MaDU, TenDU, MaLoai, DonGia))
            {
                MessageBox.Show("Sửa đồ thành công");
                LoadlistFood();
            }
            else
            {
                MessageBox.Show("Điền lại");
            }
        }

        private void BtnDeleteDink_Click(object sender, EventArgs e)
        {
            string MaDU = txbmenuID.Text;

            if (FoodDAO.Instance.DeleteMenu(MaDU))
            {
                MessageBox.Show("Xóa đồ thành công");
                LoadlistFood();
            }
            else
            {
                MessageBox.Show("Xóa lại");
            }

        }

        private void BtnSeachDink_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SeachMenuByName(txbSeachDink.Text);
        }

        private void BtnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void BtnAddAccount_Click(object sender, EventArgs e)
        {
            string Username = txbAccountName.Text;
            string TenHT = txbViewName.Text;
            int Type = (int)numType.Value;
            if(AccountDAO.Instance.InserAccount(Username, TenHT, Type))
            {
                MessageBox.Show("Thêm thành công tài khoản");
            }
            else
            {
                MessageBox.Show("Chưa thêm tài khoản");
            }
            LoadAccount();
        }

        private void BtnEditAccount_Click(object sender, EventArgs e)
        {
            string Username = txbAccountName.Text;
            string TenHT = txbViewName.Text;
            int Type = (int)numType.Value;
            if (AccountDAO.Instance.UpdateAccount(Username, TenHT, Type))
            {
                MessageBox.Show("Sửa thành công tài khoản");
            }
            else
            {
                MessageBox.Show("Chưa sửa tài khoản");
            }
            LoadAccount();
        }

        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            string Username = txbAccountName.Text;
            Deleteaccount(Username);
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            string Username = txbAccountName.Text;
            if (AccountDAO.Instance.resestpass(Username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công tài khoản");
            }
            else
            {
                MessageBox.Show("Chưa đặt lại mật khẩu tài khoản");
            }
            LoadAccount();
        }

        private void BtnViewTable_Click(object sender, EventArgs e)
        {
            LoadlistTable();
        }

        private void BtnAddTable_Click(object sender, EventArgs e)
        {
            int Maban = Convert.ToInt32(txbIDTable.Text);
            string Tenban = txbNameTable.Text;
            string TTban = txbStatus.Text;

            if (TableDAO.Instance.InserTable(Tenban,TTban))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadlistTable();
            }
            else
            {
                MessageBox.Show("Thêm lại");
            }
        }

        private void BtnEditTable_Click(object sender, EventArgs e)
        {
            int Maban =Convert.ToInt32(txbIDTable.Text);
            string Tenban = txbNameTable.Text;
            string TTban = txbStatus.Text;

            if (TableDAO.Instance.UpdateTable(Maban,Tenban, TTban))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadlistTable();
            }
            else
            {
                MessageBox.Show("Sửa lại");
            }
        }

        private void BtnDeleteTable_Click(object sender, EventArgs e)
        {
            int Maban = Convert.ToInt32(txbIDTable.Text);

            if (TableDAO.Instance.DeleteTable(Maban))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadlistTable();
            }
            else
            {
                MessageBox.Show("Xóa lại");
            }
        }

        private void BtnViewCategory_Click(object sender, EventArgs e)
        {
            LoadlistCategory();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            int Maloai = Convert.ToInt32(txbIDCategory.Text);
            string Tenloai = txbNameCategory.Text;
            if(CategoryDAO.Instance.InserCategory(Tenloai))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadlistCategory();
            }
            else
            {
                MessageBox.Show("Thêm lại");
            }
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            int Maloai = Convert.ToInt32(txbIDCategory.Text);
            string Tenloai = txbNameCategory.Text;
            if (CategoryDAO.Instance.UpdateCategory(Maloai,Tenloai))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadlistCategory();
            }
            else
            {
                MessageBox.Show("Sửa lại");
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            int Maloai = Convert.ToInt32(txbIDCategory.Text);
            string Tenloai = txbNameCategory.Text;
            if (CategoryDAO.Instance.DeleteCategory(Maloai))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadlistCategory();
            }
            else
            {
                MessageBox.Show("Xóa lại");
            }
        }
        #endregion

    }
}
