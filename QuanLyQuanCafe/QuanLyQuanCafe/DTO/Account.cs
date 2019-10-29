using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account(string userName, string tenHienthil, int type, string passWord = null)
        {
            this.UserName = userName;
            this.TenHienthi = tenHienthi;
            this.Type = type;
            this.PassWord = passWord;
        }
        public Account(DataRow row)
        {
            this.UserName = row["Username"].ToString();
            this.TenHienthi = row["TenHT"].ToString();
            this.Type = (int)row["Type"];
            this.PassWord = row["Password"].ToString();
        }
        private string userName;
        private string tenHienthi;
        private string passWord;
        private int type;

        public string UserName { get => userName; set => userName = value; }
        public string TenHienthi { get => tenHienthi; set => tenHienthi = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
