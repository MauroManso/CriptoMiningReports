using System;
using System.Collections.Generic;

namespace CriptoMiningReports.Models.consumeApi
{

    public class ApiResponse
    {
        public int id { get; set; }
        public long The24Hnumreward { get; set; }
        public long The24Hreward { get; set; }
        public long CurrentHashrate { get; set; }
        public string CurrentLuck { get; set; }
        public long Hashrate { get; set; }
        public List<MinerChart> MinerCharts { get; set; }
        public long PageSize { get; set; }
        public List<Payment> Payments { get; set; }
        public long PaymentsTotal { get; set; }
        public List<Reward> Rewards { get; set; }
        public long RoundShares { get; set; }
        public Stats Stats { get; set; }
        public List<Sumreward> Sumrewards { get; set; }
        public long UpdatedAt { get; set; }
        public Workers Workers { get; set; }
        public long WorkersOffline { get; set; }
        public long WorkersOnline { get; set; }
        public long WorkersTotal { get; set; }
        public DateTime? Date { get; set; }
    }

    public class MinerChart
    {
        public int id { get; set; }
        public long MinerHash { get; set; }
        public long MinerLargeHash { get; set; }
        public string TimeFormat { get; set; }
        public long WorkerOnline { get; set; }
        public long X { get; set; }
    }

    public class Payment
    {
        public int id { get; set; }
        public long Amount { get; set; }
        public long Timestamp { get; set; }
        public string Tx { get; set; }
    }

    public class Reward
    {
        public int id { get; set; }
        public long Blockheight { get; set; }
        public long Timestamp { get; set; }
        public long RewardReward { get; set; }
        public double Percent { get; set; }
        public bool Immature { get; set; }
        public bool Orphan { get; set; }
        public bool Uncle { get; set; }
    }

    public class Stats
    {
        public int id { get; set; }
        public long Balance { get; set; }
        public long Immature { get; set; }
        public long LastShare { get; set; }
        public long Paid { get; set; }
        public long Pending { get; set; }
    }

    public class Sumreward
    {
        public int id { get; set; }
        public long Inverval { get; set; }
        public long Reward { get; set; }
        public long Numreward { get; set; }
        public string Name { get; set; }
        public long Offset { get; set; }
    }

    public class Workers
    {
        public int id { get; set; }
        public Eth10 Eth10 { get; set; }
    }

    public class Eth10
    {
        public int id { get; set; }
        public long LastBeat { get; set; }
        public long Hr { get; set; }
        public bool Offline { get; set; }
        public long Hr2 { get; set; }
    }
}
