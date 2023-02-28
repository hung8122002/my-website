using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.BL.DepartmentBL
{
    public interface IDepartmentBL : IBaseBL<Department>
    {
        public ValidateResult getDepartment(int offset);
    }
}
