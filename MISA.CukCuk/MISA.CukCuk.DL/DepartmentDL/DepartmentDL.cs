using Dapper;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.ProcName;
using MISA.CukCuk.DL.BaseDL;

namespace MISA.CukCuk.DL.DepartmentDL
{
    public class DepartmentDL : BaseDL<Department>, IDepartmentDL
    {
        public object getDepartment(int offset)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcFilter, "Department");
            string connectionString = DataContext.ConnectionString;
            var parameters = new DynamicParameters();
            parameters.Add($"p_Offset", offset);
            var result = Acction(storeProcedureName, connectionString, "QueryMultiple", parameters);
            return result;
        }
    }
}
