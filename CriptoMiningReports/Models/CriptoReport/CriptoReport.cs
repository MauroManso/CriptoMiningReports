using System;

namespace CriptoMiningReports.Models.CriptoReport
{
    public class CriptoReport
    {
        public long Id { get; set; }
        public double EthOnPool { get; set; }
        public double EthWithdrawal { get; set; }
        public decimal EthPrice { get; set; }
        public decimal PoolPriceToday { get; set; }
        public decimal TotalValueToday { get; set; }
        public decimal TodayBalance { get; set; }
        public decimal EthValueDifferenceYesterday { get; set; }
        public double EthMinedInTheDay { get; set; }
        public double EthMinedInTheDayInReais { get; set; }
        public DateTime Date { get; set; }
    }
}