using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Resources;
using MISA.CukCuk.Common.Validate;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.EmployeeDL;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MISA.CukCuk.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region MyRegion
        private IEmployeeDL _employeeDL;
        #endregion
        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        protected override ValidateResult ValidateCustom(Employee employee, List<ErrorResult> listError, Common.Enum.Form? form)
        {
            if (!string.IsNullOrEmpty(employee.EmployeeCode) && !CodeValidate.ValidateCode(employee.EmployeeCode))
            {

                listError.Add(new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidCode,
                    DevMsg = Resource.DevMsg_InvalidCode,
                    UserMsg = Resource.UserMsg_InvalidCode
                });
            }
            if (!string.IsNullOrEmpty(employee.EmployeeCode) && GetByCode(employee.EmployeeCode).Data != null)
            {
                listError.Add(new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.DuplicateCode,
                    DevMsg = Resource.UserMsg_DuplicateCode,
                    UserMsg = Resource.UserMsg_DuplicateCode
                });
            }
            if (!string.IsNullOrEmpty(employee.FullName) && !Regex.IsMatch(employee.FullName, @"^[\p{L}\s]+$"))
            {
                listError.Add(new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidName,
                    DevMsg = Resource.DevMsg_InvalidName,
                    UserMsg = Resource.UserMsg_InvalidName
                });
            }
            if (!string.IsNullOrEmpty(employee.PhoneNumber) && Regex.IsMatch(employee.PhoneNumber, @"\w+"))
            {
                listError.Add(new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidStringNumber,
                    DevMsg = Resource.DevMsg_InvalidNumber,
                    UserMsg = Resource.UserMsg_InvalidNumber
                });
            }
            if (!string.IsNullOrEmpty(employee.Email) && !Regex.IsMatch(employee.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                listError.Add(new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidEmail,
                    DevMsg = Resource.DevMsg_InvalidEmail,
                    UserMsg = Resource.UserMsg_InvalidEmail
                });
            }
            if (listError.Count > 0)
            {
                return new ValidateResult
                {
                    IsSuccess = false,
                    listError = listError
                };
            }
            return new ValidateResult
            {
                IsSuccess = true,
            };
        }
    }
}
