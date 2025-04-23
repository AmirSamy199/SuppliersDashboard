using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Reflection;

namespace ScoposERB.Helper
{
    public class DeepHelper 
    {
       private  LocalDB fun2 = new LocalDB();
       private Connibrary.MyFunctions fun =new Connibrary.MyFunctions();
        public List<T> Getable<T>(string TableName , string Where = "NO" , string OrderBy = "NO",string connection="")
        {
            string q = $"SELECT * FROM {TableName} ";
            if (Where != "NO")
                q += $" WHERE {Where} ";
            if (OrderBy != "NO")
                q += $" ORDER BY {OrderBy} ";
            DataTable dt= new DataTable(); 
            dt= ExcecuteDT(q,connection);
            return ConvertList<T>(dt);
        }
        public List<T> GetList<T>(string q , string connection = "")
        {
            DataTable dt = new DataTable();
            dt = ExcecuteDT(q, connection);
            return ConvertList<T>(dt);
        }
        public T GetObject<T>(string q , string connection = "")
        {
            DataTable dt = new DataTable();
            dt = ExcecuteDT(q, connection);
            return ConvertOne<T>(dt);
        }
        public T GetValue<T> (string q , string Key , string connection="")
        {
            DataTable dt = new DataTable();
            dt = ExcecuteDT(q,connection);
            return (T)dt.Rows[0][Key];
        }
        public string fire (string q , string connection = "")
        {
            if(connection != "")
            {
            return  fun2.fireSQL(q,connection);
            }
            else
            {
                return fun.fireSQL(q);
            }
        }
        public DataTable fireDT(string q ,  string connection = "")
        {
            return ExcecuteDT(q, connection);
        }
        public string TryDecrypt(string Key)
        {
            try { return fun.Decrypt(Key); } catch { return Key;  }
        } 
        public string TryEncrypt(string Key)
        {
            try { return fun.Encrypt(Key); } catch { return Key;  }
        }
        //---------------------------------
        private DataTable ExcecuteDT(string q,string DB = "")
        {
            if (DB == "")
                return fun.fireDataTable(q);
            return fun2.fireDataTableSQl(q, DB);
      }
        private List<T> ConvertList<T>(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
            List<T> values = Converter.ConvertDataTable<T>(dt);
            return values;
            }
            return new List<T>();
        }  
        private T ConvertOne<T>(DataTable dt)
        {
           if(dt.Rows.Count > 0)
            {
                T value = Converter.ConvertDataTable<T>(dt).FirstOrDefault();
                return value;
            }
            return (T)new object();
            
        }
    }
    public class LocalDB
    {
        private string cs = "";
        private string cs_SQL = "";
        private DataSet ds = new DataSet();
        private OleDbConnection cn = new OleDbConnection();
        private SqlConnection cn_Sql = new SqlConnection();
        private OleDbDataAdapter ad = new OleDbDataAdapter();
        private SqlDataAdapter ad_SQL = new SqlDataAdapter();
        private OleDbCommand cmd = new OleDbCommand();
        private SqlCommand cmd_SQL = new SqlCommand();
        private DataTable dt;

        public string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        public string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        public SqlConnection fireConnectionSQl()
        {
            cn_Sql = new SqlConnection(cs_SQL);
            return cn_Sql;
        }
        public OleDbConnection fireConnectionAccess()
        {
            cn = new OleDbConnection(cs);
            return cn;
        }
        public DataTable fireDataTableSQl(string Access, string _cn_Sql)
        {
            dt = new DataTable();
            cs_SQL = _cn_Sql;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();

            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = Access;
            cmd_SQL.CommandTimeout = 0;
            ad_SQL.SelectCommand = cmd_SQL;
            cn_Sql.Close();
            ad_SQL.Fill(dt);
            return dt;
        }
        public string fireSQL(string Access, string _cn_Sql)
        {
            cs_SQL = _cn_Sql;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();
            OleDbDataReader[] dr;
            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = Access;
            cmd_SQL.CommandTimeout = 0;

            if (cmd_SQL.ExecuteScalar() != null)
                return cmd_SQL.ExecuteScalar().ToString();
            else
            {
                return "";
                cn_Sql.Close();
            }
        }

        public OleDbConnection fireConnection()
        {
            cn = new OleDbConnection(cs);
            return cn;
        }

        public LocalDB()
        {
            cn = fireConnection();
        }

      
    }
    public class Converterr
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                var columnType = column.DataType.FullName;
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (columnType == "System.String")
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? string.Empty : dr[column.ColumnName], null);
                        }
                        else if (columnType == "System.Byte")
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                        }
                        else if (columnType == "System.Int32")
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                        }
                        else if (columnType == "System.Boolean")
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                        }
                        else if (columnType == "System.Double" && pro.PropertyType.FullName == "System.String")
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName].ToString(), null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                        }

                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        static string GetType<T>(T obj)
        {
            Type type = typeof(T);
            return type.ToString(); // value-type
        }
    }
}