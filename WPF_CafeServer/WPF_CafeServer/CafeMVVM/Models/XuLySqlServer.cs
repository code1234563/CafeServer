using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CafeMVVM.Models
{
    public class XuLySqlServer
    {
        private string ChuoiKetNoi = @"Data Source=QUANGTANH\KUHEO;Initial Catalog=WPF_QuanLyCafe;Integrated Security=True";
        public DataTable LoadData(string sql)
        {
            using (SqlConnection cnn=new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable LoadDataParameter(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public bool Execute(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public object GetOneValue(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql,cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
