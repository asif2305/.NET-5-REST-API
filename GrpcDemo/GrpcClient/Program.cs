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
        public static async Task  Main(string[] args)
        {
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


            // Server Streaming RPC : Client send a single request and server respond back with multiple responses.

            await ServerStreamingDemo();
             Console.ReadLine();
          

        }
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
    }
}

