using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int maHD, DateTime? tGTT, int status,int discount = 0)
        {
            this.MaHD = maHD;
            this.TGTT = tGTT;
            this.Status = status;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.MaHD = (int)row["MaHD"];
            this.TGTT = (DateTime?)row["TGTT"];
            this.Status = (int)row["status"];

            if(row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];

        }
        private DateTime? tGTT;
        private int maHD;
        private int status;
        private int discount;
        public DateTime? TGTT { get { return tGTT; } set { tGTT = value; } }
        public int MaHD { get { return maHD; } set { maHD = value; } }

        public int Status { get { return status; } set { status = value; } }
        public int Discount { get { return discount; } set {discount = value; } }
    }
}
