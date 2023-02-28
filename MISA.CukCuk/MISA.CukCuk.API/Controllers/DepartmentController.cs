using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.DepartmentBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Resources;
using MISA.CukCuk.DL.DepartmentDL;
using MySqlConnector;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        #region Field
        private IDepartmentBL _departmentBL;
        #endregion
        public DepartmentController(IDepartmentBL departmentBL) : base(departmentBL)
        {
            _departmentBL = departmentBL;
        }

        /// <summary>
        /// Lấy 5 vị trí một lần
        /// </summary>
        /// <param name="offset">Vị trí bắt đầu lấy</param>
        [HttpGet("get-5-departments")]
        public IActionResult GetDepartment([FromQuery] int offset = 0)
        {
            try
            {
                var result = _departmentBL.getDepartment(offset);
                return StatusCode(StatusCodes.Status200OK, result.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    DevMsg = ex.Message,
                    UserMsg = DatabaseResult.UserMsg_GetFail,
                });
            }
        }

        public override IActionResult InsertEmployee([FromBody] Department record)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult DeleteById([FromRoute] Guid id)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult UpdateEmployeeById([FromRoute] Guid id, [FromBody] Department record)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult GetPaging([FromQuery] string? keyWord, [FromQuery] int limit = 10, [FromQuery] int offset = 0)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult GetNewEmployeeCode()
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult GetEmployeeByCode([FromRoute] string code)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
