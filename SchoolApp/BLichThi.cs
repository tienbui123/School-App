using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SchoolApp
{
    class BLichThi
    {
       public static List<LichThi> list;
        List<LichThi> getAll()
        {
            list = new List<LichThi>();
            string query = "select * from LichThi";
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                LichThi lt = new LichThi();
                lt.MaMH = db.Rows[i]["MaMH"].ToString();
                lt.GhepThi = db.Rows[i]["GhepThi"].ToString();
                lt.ToThi = db.Rows[i]["ToThi"].ToString();
                lt.SoLuong = int.Parse(db.Rows[i]["SoLuong"].ToString());
                lt.NgayThi = db.Rows[i]["MaMH"].ToString();
                lt.GioBD = db.Rows[i]["GioBD"].ToString();
                lt.SoPhut = int.Parse(db.Rows[i]["SoPhut"].ToString());
                lt.PhongThi = db.Rows[i]["PhongThi"].ToString();
                list.Add(lt);
            }
            return list;
        }
        void AddLT(LichThi lt)
        {
            string query = "select * from LichThi where MaMH="+lt.MaMH+",NgayThi="+lt.NgayThi;
            if (DataProvider.LoadData(query) == null)
            {
                string sql = string.Format("Insert into LichThi values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}')", lt.MaMH, lt.GhepThi, lt.ToThi, lt.SoLuong, lt.NgayThi, lt.GioBD, lt.SoPhut, lt.PhongThi);
                DataProvider.Insert(sql);
            
            }

        }

        public  static List<LichThi> LoadDataFromSV(string id)
        {
            list = new List<LichThi>();
            XmlDocument doc = new XmlDocument();
           
            doc.Load("http://localhost:56715/api/lichthi");
            XmlElement root = doc.DocumentElement;

           
           

            foreach (XmlNode node in root.ChildNodes)
            {
                LichThi lt = new LichThi();
                lt.GhepThi = node.ChildNodes[0].InnerText.Trim();
                lt.GioBD = node.ChildNodes[1].InnerText.Trim();
                lt.MaMH = node.ChildNodes[3].InnerText.Trim();
                lt.NgayThi = node.ChildNodes[4].InnerText.Trim();
                lt.PhongThi = node.ChildNodes[5].InnerText.Trim();
                lt.SoLuong = int.Parse(node.ChildNodes[6].InnerText.Trim());
                lt.SoPhut = int.Parse(node.ChildNodes[7].InnerText.Trim());
                lt.ToThi = node.ChildNodes[9].InnerText.Trim();
                list.Add(lt);
            }
           
            return list;
        }

    }
}
