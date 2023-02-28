namespace MISA.CukCuk.Common.Entities
{
    /// <summary>
    /// Thông tin phòng ban
    /// </summary>
    public class Department
    {
        /// <summary>
        /// ID phòng ban 
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban 
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
