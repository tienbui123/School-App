using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace SchoolApp
{
    class DataProvider
    {
        private static SQLiteConnection sql_con;
        private static SQLiteCommand sql_cmd;
        private static SQLiteDataAdapter DB;
        private static DataSet DS = new DataSet();
        private static DataTable DT = new DataTable();
        public static void SetConnection()
        {
            try
            {
                sql_con = new SQLiteConnection
                    ("Data Source=SchoolDB.db;Version=3;New=False;Compress=True;");
            }
            catch
            {
                SQLiteConnection.CreateFile("SchoolDB.sqlite");
                sql_con = new SQLiteConnection("Data Source=SchoolDB.sqlite;Version=3;");
                sql_con.Open();

                string sql = "create table MonHoc (MaMH varchar(20),TenMH varchar(20),SoTC varchar(20),TileThi varchar(20))";
                SQLiteCommand command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table User (Id varchar(20),HoTen varchar(20),Password varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table LichThi (MaMH varchar(20),GhepThi varchar(20),ToThi varchar(20),SoLuong int,NgayThi varchar(20),GioBD varchar(20),SoPhut int,PhongThi varchar(10))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table LichHoc (Id varchar(20,MaMH varchar(20),NhomMH varchar(20),MaLop varchar(20),ThoigianBD  varchar(20),ThoigianKT  varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table CHITIETLH (Id varchar(20),Thu varchar(20),TietBD int,SoTiet int,Phong varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table DiemThi (HocKy int,NamHoc int,DiemTB10 float,DiemTB4 float,DiemTBTL10 float,DiemTBTL4 float,SoTCDat int,SoTCTL int,DiemRL int)";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table DiemMon (MaMH varchar(20),DiemKT float,DiemThi float,DiemTK10 float,DiemTChu varchar(5),HocKy int,NamHoc int)";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();
            }
        }

        public static void Insert(string sql)
        {
            ExecuteQuery(sql);
        }

        public static DataTable LoadData(string sql)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
         
            DB = new SQLiteDataAdapter(sql, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            
            sql_con.Close();
            return DT;
        }

        private static void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

    }
}
