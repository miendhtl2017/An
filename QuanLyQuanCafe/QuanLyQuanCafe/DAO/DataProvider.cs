using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connSTR = @"Data Source=DESKTOP-R63SQRI\SQLEXPRESS;Initial Catalog=QLCP;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(data);

                conn.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(connSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                conn.Close();
            }
            return data;
        }
    }
}
