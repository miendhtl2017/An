using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set {AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            String query = "UP_Login @username , @password";

            DataTable resul = DataProvider.Instance.ExecuteQuery(query,new object[] { userName,passWord });

            return resul.Rows.Count > 0;
        }
        public DataTable GetlistAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TaiKhoan");
        }
        public bool UpdateAccountPrivate(string username, string tenHT, string password, string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @tenHT , @password , @newPassword", new object[] {username,tenHT,password,newpass });
            return result > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan where Username='"+ userName +"' ");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;

        }
        public bool InserAccount(string Username, string TenHT, int Type)
        {
            string query = string.Format("INSERT into TaiKhoan ( Username , TenHT , Type) values ( N'{0}', N'{1}', {2})", Username, TenHT, Type );
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string Username, string TenHT, int Type)
        {
            string query = string.Format("update TaiKhoan set TenHT = N'{1}' , Type = {2} where  Username = N'{0}'", Username, TenHT, Type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string Username)
        {

            string query = string.Format("Delete TaiKhoan where  Username = N'{0}'", Username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool resestpass(string Username)
        {
            string query = string.Format("update TaiKhoan set Password = N'0' where  Username = N'{0}'", Username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
