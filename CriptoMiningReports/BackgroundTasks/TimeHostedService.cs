using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CriptoMiningReports.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CriptoMiningReports.BackgroundTasks
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var request = (HttpWebRequest) WebRequest.Create("https://eth.2miners.com/api/accounts/0x5aaD3828E27bA68Afc1ACa62846E90111F458987");
            request.Method = "GET";
            using var response = (HttpWebResponse) request.GetResponse();
            using var stream = response.GetResponseStream();
            using var streamReader = new StreamReader(stream);
            var contentString = streamReader.ReadToEnd();
            var responseContentToObject = JsonConvert.DeserializeObject<ApiResponse>(contentString);
            Console.WriteLine(responseContent);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}