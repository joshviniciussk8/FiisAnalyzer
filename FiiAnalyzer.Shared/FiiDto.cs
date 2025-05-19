namespace FiiAnalyzer.Shared
{
    public class FiiDto
    {
        public string Ticker { get; set; } = string.Empty;
        public string Segmento { get; set; } = string.Empty;
        public double Price { get; set; }
        public double FFODy { get; set; }
        public double Dy { get; set; }
        public double PVP { get; set; }
        public double MarketValue { get; set; }
        public double Liquidity { get; set; }
        public int RealState { get; set; }
        public double PriceM2 { get; set; }
        public double RentM2 { get; set; }
        public double CapRate { get; set; }
        public double vacancy { get; set; }
    }
}
