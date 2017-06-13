using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Reflection;

namespace EmployeeManager.dal.dao
{
    public class DBHelper
    {
        //处理sql参数的共用方法
        public static void ProcessArgs(SqlCommand comm, params object[] args)
        {
            if (args == null)
            {
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                comm.Parameters.AddWithValue("@p" + i, args[i]);
            }
        }

        //获取类的属性信息
        //PropertyInfo是类的属性信息
        public static Dictionary<string, PropertyInfo> GetPropertyInfos(object o)
        {
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            //获取对象的类型信息
            Type type = o.GetType();
            PropertyInfo[] infos = type.GetProperties();
            foreach (PropertyInfo info in infos)
            {
                //用全小写作为key
                dic.Add(info.Name.ToLower(), info);
            }
            return dic;
        }

        public static Dictionary<string, string> GetSqlCols(SqlDataReader reader)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //查询结果的字段数量
            int cols = reader.FieldCount;
            for (int i = 0; i < cols; i++)
            {
                string name = reader.GetName(i);
                dic.Add(name.ToLower(), name);
            }
            return dic;
        }

        public static T QueryOne<T>(T t, string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                //创建T的默认值，如果是对象类型就是null
                T result = default(T);
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取类型信息
                Dictionary<string, PropertyInfo> ps = GetPropertyInfos(t);
                Dictionary<string, string> cols = GetSqlCols(reader);
                if (reader.Read())
                {
                    //创建T的实例
                    result = (T)Activator.CreateInstance(t.GetType());
                    //将数据库查询结果匹配给对象
                    foreach (string col in cols.Keys)
                    {
                        //获取数据库的字段名
                        var field = cols[col];
                        //只有匹配的字段才会赋值
                        if (ps.ContainsKey(col))
                        {
                            PropertyInfo info = ps[col];
                            //动态设置属性数据
                            info.SetValue(result, reader[field]);
                        }
                    }
                }
                reader.Close();
                conn.Close();
                return result;
            }
        }

        public static List<T> QueryList<T>(T t, string sql, params object[] args)
        {
            List<T> list = new List<T>();
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取类型信息
                Dictionary<string, PropertyInfo> ps = GetPropertyInfos(t);
                Dictionary<string, string> cols = GetSqlCols(reader);
                while (reader.Read())
                {
                    //创建T的实例
                    T result = (T)Activator.CreateInstance(t.GetType());
                    //将数据库查询结果匹配给对象
                    foreach (string col in cols.Keys)
                    {
                        //获取数据库的字段名
                        var field = cols[col];
                        //只有匹配的字段才会赋值
                        if (ps.ContainsKey(col))
                        {
                            PropertyInfo info = ps[col];
                            //动态设置属性数据
                            info.SetValue(result, reader[field]);
                        }
                    }
                    list.Add(result);
                }
                reader.Close();
                conn.Close();
                return list;
            }
        }

        public static int Update(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                int result = comm.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        public static object QueryObject(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                object result = comm.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        public static List<Dictionary<string,object>> QueryDics(string sql,params object[] args)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql,conn);
                ProcessArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取列的列表
                Dictionary<string, string> cols = GetSqlCols(reader);
                //处理查询结果
                while (reader.Read())
                {
                    //行数据用字典类处理
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    //读取列数据到字典类
                    foreach (string col in cols.Keys)
                    {
                        //注意！！！col的名称被转到全小写
                        row.Add(col, reader[col]);
                    }
                    list.Add(row);
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }
    }
}