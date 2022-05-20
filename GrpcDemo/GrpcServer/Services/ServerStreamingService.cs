using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services
{
    public class ServerStreamingService : ServerStreaming.ServerStreamingBase
    {
        private Random random;
        public ServerStreamingService()
        {
            random = new Random();
        }
        public override async Task ServerStreamingDemo(Test request, IServerStreamWriter<Test> responseStream, ServerCallContext context)
        {
            for(int i = 0; i < 10; i++)
            {
                await responseStream.WriteAsync(new Test{TestMessage = $"Message {i}" });
                var randomNumber = random.Next(1, 10);
                await Task.Delay(randomNumber * 1000);
            }
        }
    }
 
}
