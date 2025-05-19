using FiiAnalyzer.Shared;
using System.Collections.Generic;
using System.Linq;

namespace FiiAnalyzer.Core
{
    public class FiiFilter
    {
        public IEnumerable<FiiDto> FiltrarPorYield(IEnumerable<FiiDto> fiis, double minimo)
            => fiis.Where(f => f.Dy >= minimo);
        public IEnumerable<FiiDto> FiltroDefault(IEnumerable<FiiDto> fiis, double minDy)
        {
            return fiis
                .Where(f => f.FFODy <= f.Dy)
                .Where(f => f.Dy >= minDy)
                .Where(f => f.PVP >= 0.8)
                .Where(f => f.RealState >= 2.0)
                .Where(f => f.Liquidity >= 1000000);
                //.Where(f => f.RentM2 >= 0.8 && f.RentM2 <= 1.2)
                //.Where(f => f.CapRate >= 0.8 && f.CapRate <= 1.2);
        }
    }
}
