using System;
using System.Linq;
using SqlSugar;

namespace BluePI.Helper
{
    public static class SqlSugarHelper
    {
        /// <summary>
        /// 获取SqlSugar
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = "server=localhost;uid=root;pwd=123456;database=bluepi",
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true
                }
            );
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
