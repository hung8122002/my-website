namespace MISA.CukCuk.Common.Entities
{
    /// <summary>
    /// Chi tiết về lỗi khi trả về
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public Enum.ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Thông điệp dành cho developer
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông điệp dành cho người dùng
        /// </summary>
        public string UserMsg { get; set; }
    }
}