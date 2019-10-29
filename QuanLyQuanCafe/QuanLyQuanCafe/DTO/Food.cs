using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public Food(string maDU, string tenDU, int maLoai, double price)
        {
            this.MaDU = maDU;
            this.TenDU = tenDU;
            this.MaLoai = maLoai;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.MaDU = row["MaDU"].ToString();
            this.TenDU = row["TenDU"].ToString();
            this.MaLoai = (int)row["MaLoai"];
            this.Price = Convert.ToDouble( row["DonGia"].ToString());
        }
        private string maDU;
        private string tenDU;
        private int maLoai;
        private double price;

        public string MaDU { get => maDU; set => maDU = value; }
        public string TenDU { get => tenDU; set => tenDU = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public double Price { get => price; set => price = value; }
    }
}
