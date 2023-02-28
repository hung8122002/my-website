using Dapper;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.ProcName;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MISA.CukCuk.DL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        Type type = Type.GetType($"MISA.CukCuk.Common.Database.{DataContext.DatabaseName}");
        string connectionString = DataContext.ConnectionString;

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        public virtual int DeleteById(Guid id)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcDelete, typeof(T).Name);
            var parameters = new DynamicParameters();
            parameters.Add($"p_{typeof(T).Name}Id", id);
            var result = Acction(storeProcedureName, connectionString, "Excute", parameters);
            return Int32.Parse(result.ToString());
        }

        /// <summary>
        /// Tìm kiếm theo mã
        /// </summary>
        /// <param name="code">Mã</param>
        public virtual object GetByCode(string code)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcCheckExistCode, typeof(T).Name);
            var parameters = new DynamicParameters();
            parameters.Add($"p_{typeof(T).Name}Code", code);
            var result = Acction(storeProcedureName, connectionString, "QueryFirstOrDefault", parameters);
            return result;
        }

        /// <summary>
        /// Lấy mã lớn nhất
        /// </summary>
        public virtual string GetMaxCode()
        {
            string storeProcedureName = String.Format(ProcedureName.ProcGetMaxCode, typeof(T).Name);
            var result = Acction(storeProcedureName, connectionString, "QueryFirstOrDefault");
            var newResult = (dynamic)result;
            return newResult.NewCode;
        }

        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyWord">Từ khóa tìm kiếm</param>
        /// <param name="limit">Số bản ghi trên 1 trang</param>
        /// <param name="offset">Vị trí trang</param>
        public virtual PagingResult GetPaging(string? keyWord, int limit = 10, int offset = 0)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcFilter, typeof(T).Name);
            var parameters = new DynamicParameters();
            parameters.Add("p_Text", keyWord);
            parameters.Add("p_Limit", limit);
            parameters.Add("p_Offset", offset);
            var result = Acction(storeProcedureName, connectionString, "QueryMultiple", parameters);
            return (PagingResult)result;
        }

        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Bản ghi muốn thêm</param>
        /// <returns>Trả về 1 nếu insert thành công, trả về 0 nếu insert thất bại</returns>
        public virtual int InsertRecord(T record)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcInsert, typeof(T).Name);
            var parameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                parameters.Add($"p_{property.Name}", property.GetValue(record));
                var keyAttribute = (KeyAttribute?)property.GetCustomAttribute(typeof(KeyAttribute), false);
                if (keyAttribute != null)
                {
                    parameters.Add($"p_{property.Name}", Guid.NewGuid());
                }
            }
            parameters.Add("p_CreateDate", DateTime.Now);
            parameters.Add("p_CreateBy", "HungNM");
            parameters.Add("p_ModifiedDate", DateTime.Now);
            parameters.Add("p_ModifiedBy", "HungNM");
            var result = Acction(storeProcedureName, connectionString, "Excute", parameters);
            return Int32.Parse(result.ToString());
        }

        /// <summary>
        /// Sửa thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="record">Bản ghi</param>
        public virtual int UpdateById(Guid id, T record)
        {
            string storeProcedureName = String.Format(ProcedureName.ProcUpdate, typeof(T).Name);
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                parameters.Add($"p_{property.Name}", property.GetValue(record));
                var keyAttribute = (KeyAttribute?)property.GetCustomAttribute(typeof(KeyAttribute), false);
                if (keyAttribute != null)
                {
                    parameters.Add($"p_{property.Name}", id);
                }
            }
            parameters.Add("p_ModifiedDate", DateTime.Now);
            parameters.Add("p_ModifiedBy", "HungNM");
            var result = Acction(storeProcedureName, connectionString, "Excute", parameters);
            return Int32.Parse(result.ToString());
        }

        public object Acction(string storeProcedureName, string connectionString, string methodName, object? parameters = null)
        {
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName);
            object result = method.Invoke(instance, new object[] { storeProcedureName, connectionString, parameters });
            return result;
        }
    }
}
