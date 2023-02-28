using MISA.CukCuk.API.BaseController;
using MISA.CukCuk.BL;
using MISA.CukCuk.Common.Entities;

namespace MISA.CukCuk.API.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        #region MyRegion
        private IEmployeeBL _employeeBL;
        #endregion
        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
    }
}
