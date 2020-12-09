﻿using Grpc.Core;
using IntegrationAdapters.gRPCProtocol.Protos;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationAdapters.gRPCProtocol
{
    public class ClientScheduleService : IHostedService
    {
        private System.Timers.Timer timer;
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduleService() { }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(SendMessage);
            timer.Interval = 3300; // number in miliseconds  
            timer.Enabled = true;
            return Task.CompletedTask;
        }

        private async void SendMessage(object source, ElapsedEventArgs e)
        {
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = "Random message from asp.net client: " + Guid.NewGuid().ToString(), RandomInteger = new Random().Next(1, 101) });
                Console.WriteLine(response.Response + " is response; status: " + response.Status);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
