using System.Text.RegularExpressions;

namespace MISA.CukCuk.Common.Validate
{
    public class NameValidate
    {
        /// <summary>
        /// Kiểm tra tên có trống không
        /// </summary>
        /// <param name="name">Tên</param>
        /// <returns></returns>
        public static bool CheckEmptyName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra tên có hợp lệ không
        /// </summary>
        /// <param name="name">Tên</param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[\p{L}\s]+$");
        }
    }
}
