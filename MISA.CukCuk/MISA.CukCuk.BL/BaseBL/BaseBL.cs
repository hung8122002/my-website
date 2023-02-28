using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Resources;
using MISA.CukCuk.Common.Validate;
using MISA.CukCuk.DL.BaseDL;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MISA.CukCuk.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Contructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        public ValidateResult DeleteById(Guid id)
        {
            int numberAfftedRows = _baseDL.DeleteById(id);
            return new ValidateResult
            {
                IsSuccess = true,
                Data = numberAfftedRows
            };
        }

        /// <summary>
        /// Tìm kiếm theo mã
        /// </summary>
        /// <param name="code">Mã</param>
        public ValidateResult GetByCode(string code)
        {
            var validateResult = ValidateString(code);
            if (validateResult.IsSuccess)
            {
                var result = _baseDL.GetByCode(code);
                return new ValidateResult
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            else
            {
                return validateResult;
            }
        }

        /// <summary>
        /// Tạo ra một mã mới
        /// </summary>
        public ValidateResult GetNewCode()
        {
            var newCode = _baseDL.GetMaxCode();
            return new ValidateResult
            {
                IsSuccess = true,
                Data = newCode
            };
        }

        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <param name="offset">Vị trí trang</param>
        public ValidateResult GetPaging(string? keyWord, int limit = 10, int offset = 0)
        {
            var validateResult = ValidateString(keyWord);
            if (validateResult.IsSuccess)
            {
                var data = _baseDL.GetPaging(keyWord, limit, offset);
                return new ValidateResult
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            else
            {
                return validateResult;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Bản ghi</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public ValidateResult InsertRecord(T record)
        {
            var validateResult = ValidateRecord(record);
            if (validateResult.IsSuccess)
            {
                var numberAfftedRows = _baseDL.InsertRecord(record);
                return new ValidateResult
                {
                    IsSuccess = true,
                    Data = numberAfftedRows
                };
            }
            else
            {
                return validateResult;
            }
        }

        /// <summary>
        /// Sửa thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id">Id nhân viên</param>
        /// <param name="record">Thông tin bản ghi</param>
        public ValidateResult UpdateById(Guid id, T record)
        {
            var validateResult = ValidateRecord(record, Common.Enum.Form.Update);
            if (validateResult.IsSuccess)
            {
                var numberAfftedRows = _baseDL.UpdateById(id, record);
                return new ValidateResult
                {
                    IsSuccess = true,
                    Data = numberAfftedRows
                };
            }
            else
            {
                return validateResult;
            }
        }

        /// <summary>
        /// Kiểm tra thông tin chung
        /// </summary>
        /// <param name="record">Thông tin</param>
        protected virtual ValidateResult ValidateRecord(T record, Common.Enum.Form? form = Common.Enum.Form.Insert)
        {
            var properties = typeof(T).GetProperties();
            var listError = new List<ErrorResult>();
            foreach (var property in properties)
            {
                var requiredAttribute = (RequiredAttribute?)property.GetCustomAttribute(typeof(RequiredAttribute), false);
                if (requiredAttribute != null)
                {
                    if (CommonValidate.IsEmpty(property.GetValue(record).ToString()))
                    {
                        listError.Add(new ErrorResult
                        {
                            ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                            DevMsg = property.Name + " is empty",
                            UserMsg = property.Name + " is empty",
                        });
                    }
                }
            }

            if (form == Common.Enum.Form.Update)
            {
                return new ValidateResult
                {
                    IsSuccess = true,
                };
            }
            return ValidateCustom(record, listError, form); ;
        }

        /// <summary>
        /// Kiểm tra thông tin đặc biệt
        /// </summary>
        /// <param name="record">Thông tin</param>
        protected virtual ValidateResult ValidateCustom(T record, List<ErrorResult> listError, Common.Enum.Form? form)
        {
            return new ValidateResult
            {
                IsSuccess = true,
            };
        }

        /// <summary>
        /// Kiểm cho chuỗi có hợp lệ không
        /// </summary>
        /// <param name="text">Chuỗi cần kiểm tra</param>
        private ValidateResult ValidateString(string text)
        {
            string[] unExceptedList = { ";", "\"", "SELECT", "DELETE", "DROP", "INSERT" };
            foreach (var item in unExceptedList)
            {
                if (text != null && text.ToUpper().Contains(item))
                {
                    return new ValidateResult
                    {
                        IsSuccess = false,
                        Error = new ErrorResult
                        {
                            ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                            UserMsg = Resource.UserMsg_InvalidString,
                            DevMsg = Resource.DevMsg_InvalidString
                        }
                    };
                }
            }
            return new ValidateResult { IsSuccess = true };
        }
    }
}
