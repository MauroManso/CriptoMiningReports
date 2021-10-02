namespace CriptoMiningReports.Models.consumeApi
{
    public class CompleteApiObject
    {
        public ApiResponse Temperatures { get; set; }
        public MinerChart MinerChart { get; set; }
        public Payment Payment { get; set; }
        public Reward Reward { get; set; }
        public Stats Stats { get; set; }
        public Sumreward Sumreward { get; set; }
        public Workers Workers { get; set; }
    }
}