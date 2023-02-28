namespace MISA.CukCuk.Common.Entities.DTO
{
    /// <summary>
    /// Kết quả validate
    /// </summary>
    public class ValidateResult
    {
        /// <summary>
        /// Kết quả validate: true là không có lỗi, 
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Nếu không lỗi thì trả về dữ liệu
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// Nếu có lỗi thì trả về thông tin lỗi
        /// </summary>
        public ErrorResult? Error { get; set; }

        public List<ErrorResult>? listError { get; set; }
    }
}
