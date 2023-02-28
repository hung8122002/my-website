using System.Text.RegularExpressions;

namespace MISA.CukCuk.Common.Validate
{
    public class CommonValidate
    {
        /// <summary>
        /// Kiểm tra định dạng chuỗi số
        /// </summary>
        /// <param name="numberString">Chuỗi số</param>
        /// <returns></returns>
        public static bool IsValidNumber(string numberString)
        {
            return Regex.IsMatch(numberString, @"^[\d]+$");
        }

        /// <summary>
        /// Kiểm tra có rỗng hay không
        /// </summary>
        /// <param name="text">Chuỗi truyền vào</param>
        public static bool IsEmpty(string text)
        {
            return string.IsNullOrEmpty(text.Trim());
        }
    }
}
