using System;
using Grpc.Net.Client;
using GrpcServicegWithEF;
using GrpcServicegWithEF.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var input = new HelloRequest { Name = "Jnr Bond"};

            var channel = GrpcChannel.ForAddress("https://localhost:7066");
            //var client = new Greeter.GreeterClient(channel);

            //var reply = await client.SayHelloAsync(input);

            //Console.WriteLine(reply);

           var studentClient = new RemoteStudent.RemoteStudentClient(channel);
           var studentÍnput = new StudentLookupModel { StudentId = 3};
            var studentReply = await studentClient.GetStudentInfoAsync(studentÍnput);
            Console.WriteLine($"{studentReply.FirstName} | {studentReply.LastName} | {studentReply.StudentId}");

            Console.ReadLine();
        }
    }
}