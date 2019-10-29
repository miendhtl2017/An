using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;


        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int MaLoai)
        {
            List<Food> list = new List<Food>();

            string query = "select * from Menu where MaLoai =" + MaLoai;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetlistFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from Menu";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> SeachMenubyName(string TenDU)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("select * from Menu where dbo.fuConvertToUnsign1(TenDU) like N'%' + dbo.fuConvertToUnsign1(N'{0}')+'%'", TenDU);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public bool InserMenu(string MaDU, string TenDU, int MaLoai, int DonGia)
        {
            string query = string.Format("INSERT into Menu ( MaDu , TenDU , MaLoai , DonGia) values ( N'{0}', N'{1}', {2}, {3})", MaDU, TenDU, MaLoai, DonGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMenu(string MaDU, string TenDU, int MaLoai, int DonGia)
        {
            string query = string.Format("update Menu set TenDU = N'{1}' , MaLoai = {2} , DonGia = {3} where  MaDu = N'{0}'", MaDU, TenDU, MaLoai, DonGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMenu(string MaDU)
        {
            BillinfoDAO.Instance.DeleteBillinfo(MaDU);

            string query = string.Format("Delete Menu where  MaDu = N'{0}'", MaDU);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
