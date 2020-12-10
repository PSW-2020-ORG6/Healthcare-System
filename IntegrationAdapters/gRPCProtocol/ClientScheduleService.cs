using Grpc.Core;
using IntegrationAdapters.gRPCProtocol.Protos;
using IntegrationAdapters.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
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
        public String MessageResponseFromPharmacy { get; set; }
        private System.Timers.Timer timer;
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduleService() { }

       public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async void SendMessageToPharmacy(MedicineMessage message)
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { MedicineName = message.MedicineName, Quantity = message.Quantity, IsPharmacyApproved = message.IsPharmacyApproved });
                Console.WriteLine(response.Response + " is response;status: " + response.Status);
            MessageResponseFromPharmacy = response.Response;
            setingResponse(MessageResponseFromPharmacy);
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

        public void setingResponse(String message) 
        {
            Program.ResponseMessageGrpc = message;
        }
    }
}
