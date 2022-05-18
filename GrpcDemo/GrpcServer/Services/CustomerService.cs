using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }
        public override Task<CustomerModel> GetCustomerInfo(CustomerLookModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "A";
                output.LastName = "B";
            }
            else if (request.UserId == 2) {
                output.FirstName = "C";
                output.LastName = "D";
            }
            else
            {
                output.FirstName = "E";
                output.LastName = "F";
            }
            return Task.FromResult(output);
             
        }
        public override async Task GetNewCustomers(NewCustomerRequest request,
             IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
             new CustomerModel
             {
                 FirstName = "Tim",
                 LastName = "Corey",
                 EmailAddress = "tim@gmail.com",
                 Age = 41,
                 IsAlive = true,
             },
             new CustomerModel
             {
                 FirstName = "Jam",
                 LastName = "Hang",
                 EmailAddress = "jam@gmail.com",
                 Age = 43,
                 IsAlive = false,
             },
             new CustomerModel
             {
                 FirstName = "Ali",
                 LastName = "Basat",
                 EmailAddress = "ali@gmail.com",
                 Age = 20,
                 IsAlive = false,
             }
            };
            foreach (var custom in customers)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(custom);

            }
        }
    }
}
