using MISA.CukCuk.Common.Atrribute;
using System.ComponentModel.DataAnnotations;

namespace MISA.CukCuk.Common.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        [Code]
        /// <summary>
        /// Mã số 
        /// </summary>
        public string EmployeeCode { get; set; }

        [Required]
        [Name]
        /// <summary>
        /// Tên 
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Common.Enum.Gender Gender { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }

        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }

        public string IdentityNumber { get; set; }
        public string IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }
    }
}
