using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using IntegrationAdapters.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IntegrationAdapters.Services
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
            };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var result  = Encoding.UTF8.GetString(body);
                ActionAndBenefitMessage message;
                try
                { 
                    message = JsonConvert.DeserializeObject<ActionAndBenefitMessage>(result);
                } catch (Exception) 
                {
                    message = JsonConvert.DeserializeObject<ActionAndBenefitMessage>(result, new DateTimeConverter());
                }
                message.ActionID = Guid.NewGuid();
                Program.Messages.Add(message);
            };
            channel.BasicConsume(queue: "hello",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
