﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CriptoMiningReports.Database;
using CriptoMiningReports.Models;
using CriptoMiningReports.Models.consumeApi;
using CriptoMiningReports.Models.CriptoReport;
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
                TimeSpan.FromHours(6));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using var context = new Context();
            var hasTodayReport = context.ApiResponses.Any(a => a.Date.Value.Date == DateTime.Today);
            if (!hasTodayReport)
            {
                var request = (HttpWebRequest) WebRequest.Create("https://eth.2miners.com/api/accounts/0x5aaD3828E27bA68Afc1ACa62846E90111F458987");
                request.Method = "GET";
                using var response = (HttpWebResponse) request.GetResponse();
                using var stream = response.GetResponseStream();
                using var streamReader = new StreamReader(stream);
                var contentString = streamReader.ReadToEnd();
                var responseContentToObject = JsonConvert.DeserializeObject<ApiResponse>(contentString);
                
                if (responseContentToObject == null) return;
                
                responseContentToObject.Date = DateTime.Now;
                context.ApiResponses.Add(responseContentToObject);
                context.SaveChanges();

                Console.WriteLine(responseContentToObject);
            }
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