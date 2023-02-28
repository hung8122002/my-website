using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.DL.BaseDL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Bản ghi muốn thêm</param>
        /// <returns>Trả về 1 nếu insert thành công, trả về 0 nếu insert thất bại</returns>
        int InsertRecord(T record);

        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <param name="offset">Vị trí trang</param>
        public PagingResult GetPaging(string? keyWord, int limit = 10, int offset = 0);

        /// <summary>
        /// Lấy mã lớn nhất
        /// </summary>
        public string GetMaxCode();

        /// <summary>
        /// Tìm kiếm theo Code
        /// </summary>
        /// <param name="code">Code nhân viên</param>
        public object GetByCode(string code);

        /// <summary>
        /// Sửa thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="record">Bản ghi</param>
        public int UpdateById(Guid id, T record);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        public int DeleteById(Guid id);
    }
}
