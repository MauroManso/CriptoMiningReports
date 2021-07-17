using Microsoft.EntityFrameworkCore;

namespace CriptoMiningReports.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}