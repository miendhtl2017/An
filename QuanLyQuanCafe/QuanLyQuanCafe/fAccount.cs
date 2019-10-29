using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class fAccount : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount); }
        }

        public fAccount(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void changeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbHienthi.Text = LoginAccount.TenHienthi;
        }

        void UpdateAccountinfo()
        {
            string UserName = txbUserName.Text;
            string TenHT = txbHienthi.Text;
            string PassWord = txbPassWord.Text;
            string NewPass = txbNewPass.Text;
            string reenterPass = txbRetype.Text;

            if (!NewPass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccountPrivate(UserName, TenHT, PassWord, NewPass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(UserName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;

        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountinfo();
        }

        public class AccountEvent:EventArgs
        {
            private Account acc;

            public Account Acc { get => acc; set => acc = value; }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
    }
}
