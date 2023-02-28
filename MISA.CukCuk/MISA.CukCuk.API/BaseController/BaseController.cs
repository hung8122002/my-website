using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Framing;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Resources;

namespace MISA.CukCuk.API.BaseController
{
    [Route("api/[controller]")]
    [EnableCors("Policy")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field
        private IBaseBL<T> _BaseBL;
        #endregion

        #region Contructor
        public BaseController(IBaseBL<T> BaseBL)
        {
            _BaseBL = BaseBL;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Bản ghi</param>
        [HttpPost]
        public virtual IActionResult InsertEmployee([FromBody] T record)
        {
            try
            {
                var data = _BaseBL.InsertRecord(record);
                if (data.IsSuccess && Convert.ToUInt32(data.Data) != 0)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else if (data.IsSuccess && Convert.ToUInt32(data.Data) == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.ServerError,
                        UserMsg = DatabaseResult.UserMsg_InsertFail,
                        DevMsg = DatabaseResult.DevMsg_InsertFail,
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, data.listError);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    UserMsg = Resource.UserMsg_ServerError,
                    DevMsg = ex.Message,
                });
            }
        }

        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <param name="offset">Vị trí trang</param>
        [HttpGet("filter")]
        public virtual IActionResult GetPaging(
            [FromQuery] string? keyWord,
            [FromQuery] int limit = 10,
            [FromQuery] int offset = 0
            )
        {
            try
            {
                var data = _BaseBL.GetPaging(keyWord, limit, offset);
                if (data.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, data.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, data.Error);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    UserMsg = DatabaseResult.UserMsg_GetFail,
                    DevMsg = ex.Message,
                });
            }
        }

        /// <summary>
        /// Tạo ra một mã mới
        /// </summary>
        [HttpGet("new-code")]
        public virtual IActionResult GetNewEmployeeCode()
        {
            try
            {
                var result = _BaseBL.GetNewCode();
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

        /// <summary>
        /// Tìm kiếm theo mã
        /// </summary>
        /// <param name="code">Mã</param>
        [HttpGet("{code}")]
        public virtual IActionResult GetEmployeeByCode([FromRoute] string code)
        {
            try
            {
                var data = _BaseBL.GetByCode(code);

                if (data.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, data.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, data.Error);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    UserMsg = DatabaseResult.UserMsg_GetFail,
                    DevMsg = ex.Message,
                });
            }

        }

        /// <summary>
        /// Sửa thông tin theo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="record">Bản ghi</param>
        [HttpPut("{Id}")]
        public virtual IActionResult UpdateEmployeeById([FromRoute] Guid id, [FromBody] T record)
        {
            try
            {
                var data = _BaseBL.UpdateById(id, record);
                if (data.IsSuccess && Convert.ToUInt32(data.Data) != 0)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else if (data.IsSuccess && Convert.ToUInt32(data.Data) == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enum.ErrorCode.ServerError,
                        UserMsg = DatabaseResult.UserMsg_UpdateFail,
                        DevMsg = DatabaseResult.DevMsg_UpdateFail,
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, data.listError);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    UserMsg = DatabaseResult.UserMsg_UpdateFail,
                    DevMsg = ex.Message,
                });
            }
        }

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        [HttpDelete("{Id}")]
        public virtual IActionResult DeleteById([FromRoute] Guid id)
        {
            try
            {
                var result = _BaseBL.DeleteById(id);
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.ServerError,
                    UserMsg = DatabaseResult.UserMsg_DeleteFail,
                    DevMsg = ex.Message,
                });
            }
        }
        #endregion
    }
}
