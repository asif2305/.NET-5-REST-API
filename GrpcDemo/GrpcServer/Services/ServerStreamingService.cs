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
        public override async Task<Test> ClientStreamingDemo(IAsyncStreamReader<Test> requestStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                Console.WriteLine(requestStream.Current.TestMessage);
            }
            Console.WriteLine("Client "); 
            return new Test { TestMessage = "Sample" };  
        }
        public override async Task BidirectionalStreamingDemo(IAsyncStreamReader<Test> requestStream, IServerStreamWriter<Test> responseStream, ServerCallContext context)
        {
            var tasks = new List<Task>();
            while(await requestStream.MoveNext())
            {
                Console.WriteLine($"Received Request:" + requestStream.Current.TestMessage);
                var task = Task.Run(async () => 
                {
                    var message = requestStream.Current.TestMessage;
                    var randomNumber = random.Next(1, 10);
                    await Task.Delay(randomNumber * 1000);
                    await responseStream.WriteAsync(new Test { TestMessage = message });
                    Console.WriteLine("Sent Response" + message);
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
            Console.WriteLine("Bidirectional Streaming Completed");
        }
    }
   
 
}
