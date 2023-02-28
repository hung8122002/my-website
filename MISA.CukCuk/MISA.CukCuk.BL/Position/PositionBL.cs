using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.DepartmentDL;
using MISA.CukCuk.DL.PositionDL;

namespace MISA.CukCuk.BL.Position
{
    public class PositionBL : BaseBL<Positioncs>, IPositionBL
    {
        #region Field
        private IPositionDL _PositionDL;
        #endregion
        public PositionBL(IPositionDL positionDL) : base(positionDL)
        {
            _PositionDL = positionDL;
        }

        public ValidateResult getPosition(int offset)
        {
            var result = _PositionDL.getPosition(offset);
            return new ValidateResult
            {
                IsSuccess = true,
                Data = result
            };
        }
    }
}
