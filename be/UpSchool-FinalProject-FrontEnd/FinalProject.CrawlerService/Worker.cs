using FinalProject.Application.Common.Models.WorkerService;
using FinalProject.Application.Features.Orders.Queries.GetById;
using Microsoft.AspNetCore.SignalR.Client;

namespace FinalProject.CrawlerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HubConnection _connection;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            _connection=new HubConnectionBuilder()
                .WithUrl($"\"https://localhost:7220/Hubs/OrderHub")
                .WithAutomaticReconnect()
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _connection.On<OrderGetByIdDto, string>("NewOrderAdded", (order, accessToken) =>
            {
                Console.WriteLine($"A new order Added.");
                Console.WriteLine($"Our access token is {accessToken}");
               

            });
            await _connection.StartAsync(stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(1000, stoppingToken);
            }
        }
    }
}