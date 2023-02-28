namespace MISA.CukCuk.Common.Entities.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public long TotalRecord { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public decimal TotalPage { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
    }
}
