using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        private static Random random;
        public static async Task  Main(string[] args)
        {
            random = new Random();
            var input = new HelloRequest { Name = "Tim" };
            var channel = GrpcChannel.ForAddress("https://localhost:7078");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);

            // channel = GrpcChannel.ForAddress("https://localhost:7078");
           var customerClient = new Customer.CustomerClient(channel);
           var clientRequested = new CustomerLookModel { UserId = 1};
           var customer =  await customerClient.GetCustomerInfoAsync(clientRequested);
            
            Console.WriteLine($"{customer.FirstName}{customer.LastName}");
            Console.WriteLine();
            Console.WriteLine("New Customer List ");
            using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;
                    Console.WriteLine($"{currentCustomer.FirstName} :" +
                        $"  {currentCustomer.LastName} {currentCustomer.EmailAddress} : {currentCustomer.Age} :" +
                        $"{currentCustomer.IsAlive}");
                }
            }
            var client3 = new Product.ProductClient(channel);
            var stockDate = DateTime.SpecifyKind(new DateTime(2022,05,20), DateTimeKind.Utc);
            var productResponse = await client3.SaveProductAsync(new ProductModel
            {
                ProductName = "Mackbook Pro",
                ProductCode = "25652",
                Price = 6000,
                StockDate = Timestamp.FromDateTime(stockDate)
            }); ;
            Console.WriteLine($"{productResponse.StatusCode} | {productResponse.IsSuccessful}");

            var productResponse2 = await client3.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());

            foreach(var product in productResponse2.Products)
            {
                var stockDate2 = product.StockDate.ToDateTime();
                Console.WriteLine($"{product.ProductName} | {product.ProductCode} | {product.Price} | {stockDate2.ToString("dd-MM-yyyy")}");
            }



            //await ServerStreamingDemo();
            //await ClientStreamingDemo();
            await BidirectionalStreamingDemo();
            Console.ReadLine();
          

        }
        // Client Streaming RPC: Client send multiple requests and server respond back with a single response
        private static async Task ClientStreamingDemo()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7078");
            var client = new ServerStreaming.ServerStreamingClient(channel);
            var stream = client.ClientStreamingDemo();
            for(int i = 0; i <=10; i++)
            {
                await stream.RequestStream.WriteAsync(new Test { TestMessage =$"Message {i}"});
                var rN = random.Next(1, 10);
                await Task.Delay(rN * 1000);
            }
            await stream.RequestStream.CompleteAsync();
            Console.WriteLine("Client Streaming Completed");
            await channel.ShutdownAsync();

        }

        // Server Streaming RPC : Client send a single request and server respond back with multiple responses.
        private static async Task ServerStreamingDemo()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7078");
            var client = new ServerStreaming.ServerStreamingClient(channel);
            var response = client.ServerStreamingDemo(new Test { TestMessage ="Test"});
            while (await response.ResponseStream.MoveNext(CancellationToken.None))
            {
                var value = response.ResponseStream.Current.TestMessage;
                Console.WriteLine(value);
            }
            Console.WriteLine("Server Streaming Completed");
            await channel.ShutdownAsync();
           
        }
        // Bidirectional Streaming RPC: Both request and response will be a stream of messages.
        public static async Task BidirectionalStreamingDemo()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7078");
            var client = new ServerStreaming.ServerStreamingClient(channel);
            var stream = client.BidirectionalStreamingDemo();
            var requestTask = Task.Run(async () =>
            {
                for(int i=0; i<10; i++)
                {
                    var rN = random.Next(1, 10);
                    await Task.Delay(rN * 1000);
                    await stream.RequestStream.WriteAsync(new Test { TestMessage = i.ToString() });
                    Console.WriteLine("Send request"+ i);
                }
                await stream.RequestStream.CompleteAsync();
            });
            var responseTask = Task.Run(async () =>
            {
                while (await stream.ResponseStream.MoveNext(CancellationToken.None))
                {
                   Console.WriteLine("Received Response: "+ stream.ResponseStream.Current.TestMessage);
                }
                Console.WriteLine("Response Stream Completed");
            });
            await Task.WhenAll(requestTask, responseTask);
            await channel.ShutdownAsync();
        }

    }
}

