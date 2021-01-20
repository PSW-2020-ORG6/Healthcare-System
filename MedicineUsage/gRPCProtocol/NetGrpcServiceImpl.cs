using Grpc.Core;
using MedicineUsage.gRPCProtocol.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineUsage.gRPCProtocol
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public NetGrpcServiceImpl(){
        }
        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = "STATUS OK";
            return Task.FromResult(response);
        }
    }
}
