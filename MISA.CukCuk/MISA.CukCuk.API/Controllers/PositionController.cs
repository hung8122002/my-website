using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.API.BaseController;
using MISA.CukCuk.BL;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.Position;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Resources;
using MySqlConnector;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController<Positioncs>
    {
        #region MyRegion
        private IPositionBL _positionBL;
        #endregion
        public PositionController(IPositionBL positionBL) : base(positionBL)
        {
            _positionBL = positionBL;
        }

        [HttpGet("get-5-positions")]
        public IActionResult GetDepartment([FromQuery] int offset = 0)
        {
            try
            {
                var result = _positionBL.getPosition(offset);
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

        public override IActionResult InsertEmployee([FromBody] Positioncs record)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult DeleteById([FromRoute] Guid id)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public override IActionResult UpdateEmployeeById([FromRoute] Guid id, [FromBody] Positioncs record)
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
