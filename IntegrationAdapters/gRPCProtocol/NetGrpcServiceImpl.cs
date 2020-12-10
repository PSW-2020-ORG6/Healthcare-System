using Grpc.Core;
using IntegrationAdapters.gRPCProtocol.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.gRPCProtocol
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public String MessageResponseFromPharmacy { get; set; }
        public Boolean IsReceived { get; set; }
        public NetGrpcServiceImpl(){
            IsReceived = false;
         }
        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            this.IsReceived = true;
            this.MessageResponseFromPharmacy = request.MedicineName;
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = "STATUS OK";
            return Task.FromResult(response);
        }
    }
}
