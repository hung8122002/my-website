namespace MISA.CukCuk.Common.ProcName
{
    public static class ProcedureName
    {
        /// <summary>
        /// Procedure thêm mới nhân viên
        /// </summary>
        public static string ProcInsert = "Proc_{0}_Insert";

        /// <summary>
        /// Procedure lọc
        /// </summary>
        public static string ProcFilter = "Proc_{0}_Filter";

        /// <summary>
        /// Procedure lấy mã nhân viên lớn nhất
        /// </summary>
        public static string ProcGetMaxCode = "Proc_{0}_GetMaxCode";

        /// <summary>
        /// Procedure tìm kiếm nhân viên theo mã
        /// </summary>
        public static string ProcCheckExistCode = "Proc_{0}_FindByCode";

        /// <summary>
        /// Procedure sửa thông tin nhân viên
        /// </summary>
        public static string ProcUpdate = "Proc_{0}_Update";

        /// <summary>
        /// Procedure xóa nhân viên
        /// </summary>
        public static string ProcDelete = "Proc_{0}_Delete";
    }
}
