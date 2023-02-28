using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.BL.Position
{
    public interface IPositionBL : IBaseBL<Positioncs>
    {
        public ValidateResult getPosition(int offset);
    }
}
