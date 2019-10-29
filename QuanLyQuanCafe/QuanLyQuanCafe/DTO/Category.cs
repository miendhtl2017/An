using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        public Category(int maLoai, string tenLoai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
        }
        public Category(DataRow row)
        {
            this.MaLoai = (int)row["MaLoai"];
            this.TenLoai = row["tenLoai"].ToString();
        }
        private int maLoai;
        private string tenLoai;

        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
    }
}