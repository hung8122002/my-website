using Dapper;
using MISA.CukCuk.Common.Entities.DTO;
using MySqlConnector;

namespace MISA.CukCuk.Common.Database
{
    public class MySQL : IAction
    {
        public int Excute(string storeProcedureName, string connectionString, object? parameters)
        {
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        int numberOfAffectedRows = mySqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return numberOfAffectedRows;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return 0;
                    }
                }

            }
        }

        public object QueryFirstOrDefault(string storeProcedureName, string connectionString, object? parameters)
        {
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                object result = mySqlConnection.QueryFirstOrDefault(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public object QueryMultiple(string storeProcedureName, string connectionString, object? parameters)
        {
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var result = mySqlConnection.QueryMultiple(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var data = result.Read();
                var total = result.Read().FirstOrDefault();
                return new PagingResult
                {
                    TotalRecord = total.TotalRecord,
                    TotalPage = total.TotalPage,
                    Data = data,
                };
            }
        }
    }
}
