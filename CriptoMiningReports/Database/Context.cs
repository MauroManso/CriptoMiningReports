using CriptoMiningReports.Models;
using CriptoMiningReports.Models.consumeApi;
using CriptoMiningReports.Models.CriptoReport;
using Microsoft.EntityFrameworkCore;

namespace CriptoMiningReports.Database
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        public DbSet<ApiResponse> ApiResponses {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=reports.db");
        }
    }
}