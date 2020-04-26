using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Data
{
    public class DataProvider
    {
        string strConnection = "server = DESKTOP-P8RV0NJ\\SQLEXPRESS;database=QLHS;uid=sa;pwd=19011999";
        private static DataProvider _instance;
        private DataProvider() { }
        public static DataProvider GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataProvider();
            }
            return _instance;
        }
        public DataTable ExcuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = new SqlConnection(strConnection))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                if (parameters != null)
                {
                    string[] param = query.Split(' ');
                    int i = 0;
                    foreach (var item in param)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }

                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                cnn.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection cnn = new SqlConnection(strConnection))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                if (parameters != null)
                {
                    string[] param = query.Split(' ');
                    int i = 0;
                    foreach (var item in param)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }

                }
                data = cmd.ExecuteNonQuery();
                cnn.Close();
            }
            return data;
        }
        public object ExcuteScalar(string query, object[] parameters = null)
        {
            object data = 0;
            using (SqlConnection cnn = new SqlConnection(strConnection))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                if (parameters != null)
                {
                    string[] param = query.Split(' ');
                    int i = 0;
                    foreach (var item in param)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }

                }
                data = cmd.ExecuteScalar();
                cnn.Close();
            }
            return data;
        }
    }
}
