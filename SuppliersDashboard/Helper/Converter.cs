using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SuppliersDashboard.Helper
{
    public class Converter
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

        internal static object ConvertDataTable<T>(HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }
    }
}