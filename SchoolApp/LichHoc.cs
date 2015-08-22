using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class LichHoc
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        List<chiTietLH> chitiet;

        internal List<chiTietLH> Chitiet
        {
            get { return chitiet; }
            set { chitiet = value; }
        }
        string maMH;

        public string MaMH
        {
            get { return maMH; }
            set { maMH = value; }
        }

        string nhomMH;

        public string NhomMH
        {
            get { return nhomMH; }
            set { nhomMH = value; }
        }
        string maLop;

        public string MaLop
        {
            get { return maLop; }
            set { maLop = value; }
        }


        string thoigianBD;

        public string ThoigianBD
        {
            get { return thoigianBD; }
            set { thoigianBD = value; }
        }
        string thoigianKT;

        public string ThoigianKT
        {
            get { return thoigianKT; }
            set { thoigianKT = value; }
        }
    }
}
