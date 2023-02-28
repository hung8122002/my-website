using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Database
{
    internal interface IAction
    {
        object QueryFirstOrDefault(string storeProcedureName, string connectionString, object? parameters);

        int Excute(string storeProcedureName, string connectionString, object? parameters);

        object QueryMultiple(string storeProcedureName, string connectionString, object? parameters);
    }
}
