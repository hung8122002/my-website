using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.DepartmentDL;

namespace MISA.CukCuk.BL.DepartmentBL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        #region Field
        private IDepartmentDL _DepartmentDL;
        #endregion
        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _DepartmentDL = departmentDL;
        }

        public ValidateResult getDepartment(int offset)
        {
            var result = _DepartmentDL.getDepartment(offset);
            return new ValidateResult
            {
                IsSuccess = true,
                Data = result
            };
        }
    }
}
