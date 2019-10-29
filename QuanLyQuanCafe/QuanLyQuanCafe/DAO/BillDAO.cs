using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUnCheckBillIDTableId(int MaBan)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * FROM HoaDon WHERE MaBan = '" + MaBan + "' AND status = 0 ");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.MaHD;
            }
            return -1;
        }

        public void CheckOut(int MaHD, int discount , float totalPrice)
        {
            string query = "UPDATE HoaDon SET status = 1 ,"+"discount ="+ discount +", totalPrice ="+ totalPrice +"WHERE MaHD = " + MaHD;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int MaBan)
        {
            DataProvider.Instance.ExecuteNonQuery("exec sp_InsertHD @maban ", new object[] {MaBan});
        }

        public DataTable GhetBillDate(DateTime ngayTT)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_LayDanhHoaDonTheoNgay @ngayTT", new object[] { ngayTT });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(MaHD) FROM HoaDon");
                
            }
            catch(Exception)
            {
                return 1;
            }
        }
    }
}
