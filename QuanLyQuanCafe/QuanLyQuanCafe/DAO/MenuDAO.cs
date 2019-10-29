using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int MaBan)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT f.TenDU, bi.count, f.DonGia, f.DonGia*bi.count AS totalPrice FROM ChiTietHD AS bi,HoaDon AS b, Menu AS f WHERE bi.MaHD = b.MaHD AND bi.MaDU = f.MaDU and b.status=0 AND b.MaBan = "+ MaBan;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
