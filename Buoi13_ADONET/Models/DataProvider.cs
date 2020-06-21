using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ASPCore.ADONETLab.Models
{
    public class DataProvider
    {
        public static string ChuoiKetNoi
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();
                return config.GetConnectionString("MyDB");
            }
        }
        public static bool TruyVan_XuLy(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection(ChuoiKetNoi);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable TruyVan_LayDuLieu(string sql)
        {
            SqlConnection con = new SqlConnection(ChuoiKetNoi);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable kq = new DataTable();
            da.Fill(kq);
            return kq;
        }

        public static void ExcuteNonQuery(string sql, CommandType type, SqlParameter[] paras)
        {
            SqlConnection sqlcon = new SqlConnection(ChuoiKetNoi);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = sql;
            cmd.CommandType = type;

            if (paras != null)//có tham số
                cmd.Parameters.AddRange(paras);

            cmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        public static DataTable SelectData(string sql, CommandType type, SqlParameter[] paras)
        {
            DataTable kq = new DataTable();
            SqlConnection sqlcon = new SqlConnection(ChuoiKetNoi);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = sql;
            cmd.CommandType = type;

            if (paras != null)
                cmd.Parameters.AddRange(paras);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(kq);

            sqlcon.Close();
            return kq;
        }
        public static DataSet SelectMultiData(string sql)
        {
            DataSet kq = new DataSet();
            SqlConnection sqlcon = new SqlConnection(ChuoiKetNoi);
            sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            da.Fill(kq);

            sqlcon.Close();
            return kq;
        }
    }
}
