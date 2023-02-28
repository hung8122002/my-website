namespace MISA.CukCuk.Common.Enum
{
    /// <summary>
    /// Thông tin về giới tính
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 0,
        /// <summary>
        /// Nữ
        /// </summary>
        Female = 1,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }

    /// <summary>
    /// Thông tin về Error Code
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidInput = 400,

        /// <summary>
        /// Lỗi dữ mã không hợp lệ
        /// </summary>
        InvalidCode = 401,

        /// <summary>
        /// Lỗi tên không hợp lệ
        /// </summary>
        InvalidName = 402,

        /// <summary>
        /// Lỗi dữ id vào không hợp lệ
        /// </summary>
        InvalidId = 403,

        /// <summary>
        /// Lỗi email vào không hợp lệ
        /// </summary>
        InvalidEmail = 406,

        /// <summary>
        /// Lỗi chuỗi số không hợp lệ
        /// </summary>
        InvalidStringNumber = 405,

        /// <summary>
        /// Lỗi sai url
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Lỗi trùng mã
        /// </summary>
        DuplicateCode = 407,

        /// <summary>
        /// Lỗi phía back-end
        /// </summary>
        ServerError = 500,
    }

    public enum Form
    {
        Update = 0,
        Insert = 1,
    }
}
