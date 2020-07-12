using System;
using System.Data.SqlClient;

namespace CH01_CodingStandardsAndPrinciples.GoodCode.Data
{
    public class DatabaseManager
    {
        #region Database Operations

        public void OpenDatabaseConnection() { throw new NotImplementedException(); }
        public void CloseDatabaseConnection() { throw new NotImplementedException(); }
        public int ExecuteSql(string sql) { throw new NotImplementedException(); }
        public SqlDataReader SelectSql(string sql) { throw new NotImplementedException(); }
        public int UpdateSql(string sql) { throw new NotImplementedException(); }
        public int DeleteSql(string sql) { throw new NotImplementedException(); }
        public int InsertSql(string sql) { throw new NotImplementedException(); }

        #endregion
    }
}
