using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from Loai";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public bool InserCategory(string Tenloai)
        {
            string query = string.Format("INSERT into Loai (TenLoai ) values ( N'{0}')", Tenloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategory(int Maloai, string Tenloai)
        {
            string query = string.Format("update Loai set TenLoai = N'{1}' where  MaLoai = {0}", Maloai, Tenloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int Maloai)
        {

            string query = string.Format("Delete Loai where  MaLoai = {0}", Maloai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public Category GetCategoryByID(int MaLoai)
        {
            Category category = null;

            string query = "select * from Loai where MaLoai = " + MaLoai;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
    }
}
