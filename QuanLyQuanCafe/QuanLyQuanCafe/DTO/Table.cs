using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        public Table(int maban,string tenban, string ttban)
        {
            this.Maban = maban;
            this.Tenban = tenban;
            this.TTBan = TTBan;
        }
        public Table(DataRow row)
        {
            this.Maban = (int)row["MaBan"];
            this.Tenban = row["TenBan"].ToString();
            this.TTBan= row["TTBan"].ToString();
        }
        private int maban;
        private string tenban;

        private string ttban;

        public string TTBan { get { return ttban; } set { ttban = value; } }
        public int Maban { get {return maban; } set { maban = value; } }

        public string Tenban { get => tenban; set => tenban = value; }
    }
}
