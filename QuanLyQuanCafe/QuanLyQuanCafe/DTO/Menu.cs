using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Menu
    {
        public Menu(string dinkName, int count, float price, float totalPrice = 0)
        {
            this.DinkName = dinkName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow row)
        {
            this.DinkName = row["TenDU"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private float totalPrice;
        private float price;
        private int count;
        private string dinkName;

       
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public string DinkName { get => dinkName; set => dinkName = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
