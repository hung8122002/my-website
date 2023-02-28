using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.BL.BaseBL
{
    public interface IBaseBL<T>
    {
        #region MyRegion
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Bản ghi muốn thêm</param>
        /// <returns>Trả về 1 nếu insert thành công, trả về 0 nếu insert thất bại</returns>
        public ValidateResult InsertRecord(T record);

        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <param name="offset">Vị trí trang</param>
        public ValidateResult GetPaging(string? keyWord, int limit = 10, int offset = 0);

        /// <summary>
        /// Tạo ra một mã mới
        /// </summary>
        public ValidateResult GetNewCode();

        /// <summary>
        /// Tìm kiếm theo mã
        /// </summary>
        /// <param name="employeeCode">Mã</param>
        public ValidateResult GetByCode(string code);

        /// <summary>
        /// Sửa thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="record">Bản ghi</param>
        public ValidateResult UpdateById(Guid id, T record);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        public ValidateResult DeleteById(Guid id);
        #endregion
    }
}
