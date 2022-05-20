using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services
{
    public class ProductService : Product.ProductBase
    {
        public override Task<ProductSaveResponse> SaveProduct(ProductModel request, ServerCallContext context)
        {
            Console.WriteLine($"{request.ProductName} | {request.ProductCode} | {request.Price}");
            var result = new ProductSaveResponse
            {
                StatusCode = 1,
                IsSuccessful = true
            };
            return Task.FromResult(result);
        }
    }
}
