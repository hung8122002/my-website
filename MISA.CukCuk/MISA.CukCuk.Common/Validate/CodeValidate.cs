using Dapper;
using MySqlConnector;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Common.Validate
{
    public class CodeValidate
    {
        /// <summary>
        /// Kiểm tra mã nhân viên có trống không
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <returns></returns>
        public static bool CheckEmptyCode(string code)
        {
            if (string.IsNullOrEmpty(code.Trim()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra mã nhân viên hợp lệ
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <returns></returns>
        public static bool ValidateCode(string code)
        {
            var pattern = "^NV-[0-9]{5}$";
            return Regex.IsMatch(code, pattern);
        }

        /// <summary>
        /// Kiểm tra mã nhân viên có trùng không
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <returns></returns>
        public static bool IsExistCode(string code)
        {
            // Chuẩn bị 
            string storeProcedureName = "Proc_Employee_FindByCode";
            var parameters = new DynamicParameters();
            parameters.Add("p_EmployeeCode", code);

            // Khỏi tạo kết nối
            string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.AMIS.MF1531.HUNGNM;Uid=nvmanh;Pwd=12345678;";
            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            // Gọi vào database
            var result = mySqlConnection.QueryFirstOrDefault(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            // Đóng kết nối
            mySqlConnection.Close();

            // Xử lý kết quả
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
