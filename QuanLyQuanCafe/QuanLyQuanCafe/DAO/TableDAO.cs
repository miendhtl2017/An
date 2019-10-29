using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set {TableDAO.instance = value; }
        }
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public List<Table> LoadTablelist()
        {
            List<Table> tablelist = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("sp_getban");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            
            return tablelist;
        }
        public bool InserTable(string Tenban, string TTban)
        {
            string query = string.Format("INSERT into Ban (TenBan , TTBan) values ( N'{0}', N'{1}')",Tenban,TTban);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int Maban, string Tenban, string TTban)
        {
            string query = string.Format("update Ban set TenBan = N'{1}' , TTBan = N'{2}' where  MaBan = {0}", Maban,Tenban,TTban);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int Maban)
        {

            string query = string.Format("Delete Ban where  MaBan = {0}", Maban);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_ChuyenBan @idBan1 , @idBan2 ", new object[] { id1, id2 });
        }
        public void PooledTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_GopBan @idBan1 , @idBan2 ", new object[] { id1, id2 });
        }
    }
}
