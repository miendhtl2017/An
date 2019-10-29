using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Billinfo
    {
        public Billinfo(int maCTHD, string maDU, int maHD, int count)
        {
            this.MaCTHD = maCTHD;
            this.MaDU = maDU;
            this.MaHD = maHD;
            this.Count = count;
        }

        public Billinfo(DataRow row)
        {
            this.MaCTHD = (int)row["MaCTHD"];
            this.MaDU = row["MaDU"].ToString();
            this.MaHD = (int)row["MaHD"];
            this.Count = (int)row["Count"];
        }
        private int maCTHD;
        private string maDU;
        private int maHD;
        private int count;

        public int MaCTHD { get { return maCTHD; } set { maCTHD = value; } }

        public string MaDU { get { return maDU; } set { maDU = value; } }
      
        public int MaHD { get {return maHD; } set { maHD = value; } }
        public int Count { get { return count; } set { count = value; } }
    }
}
