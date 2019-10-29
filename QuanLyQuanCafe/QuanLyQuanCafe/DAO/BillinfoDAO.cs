using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillinfoDAO
    {
        private static BillinfoDAO instance;

        public static BillinfoDAO Instance
        {
            get { if (instance == null) instance = new BillinfoDAO(); return BillinfoDAO.instance; }
            private set { instance = value; }
        }
        public BillinfoDAO() { }
        public void DeleteBillinfo(string MaDU)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Delete ChiTietHD where MaDU = '" + MaDU + "'");
        }
        public List<Billinfo> GetlistBillinfo(int MaHD)
        {
            List<Billinfo> listBillinfo = new List<Billinfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from ChiTietHD where MaHD = " + MaHD);

            foreach(DataRow item in data.Rows)
            {
                Billinfo info = new Billinfo(item);
                listBillinfo.Add(info);
            }

            return listBillinfo;
        }
        public void InsertBillInfo(int MaHD, string MaDU, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_ThemChiTietHaDon @maHD , @maDU , @count", new object[] { MaHD, MaDU, count });
        }
    }
}
