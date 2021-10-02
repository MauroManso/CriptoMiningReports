using System.Linq;
using CriptoMiningReports.Database;
using Microsoft.AspNetCore.Mvc;

namespace CriptoMiningReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            using var context = new Context();
            return Ok(context.ApiResponses.ToList());
        }
    }
}