using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.DL.BaseDL;

namespace MISA.CukCuk.DL.DepartmentDL
{
    public interface IDepartmentDL : IBaseDL<Department>
    {
        public object getDepartment(int offset);
    }
}
