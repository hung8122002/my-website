using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.DL.BaseDL;

namespace MISA.CukCuk.DL.PositionDL
{
    public interface IPositionDL : IBaseDL<Positioncs>
    {
        public object getPosition(int offset);
    }
}
