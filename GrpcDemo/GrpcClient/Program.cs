using System;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task  Main(string[] args)
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
            var productResponse = await client3.SaveProductAsync(new ProductModel
            {
                ProductName =  "Mackbook Pro",
                ProductCode = "25652",
                Price = 6000
            });
            Console.WriteLine($"{productResponse.StatusCode} | {productResponse.IsSuccessful}");
            await channel.ShutdownAsync();
            Console.ReadLine();





        }
    }
}

