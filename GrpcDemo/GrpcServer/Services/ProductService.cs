﻿using Google.Protobuf.WellKnownTypes;
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
        public override Task<ProductList> GetProducts(Empty request, ServerCallContext context)
        {
            var stockDate = DateTime.SpecifyKind(new DateTime(2022, 05, 20), DateTimeKind.Utc);
            var product1 = new ProductModel
            {
                ProductName = "Product 001",
                ProductCode = "P01",
                Price = 100,
                StockDate = Timestamp.FromDateTime(stockDate)
            };
            var product2 = new ProductModel
            {
                ProductName = "Product 002",
                ProductCode = "P02",
                Price = 200,
                StockDate = Timestamp.FromDateTime(stockDate)
            };
            var product3 = new ProductModel
            {
                ProductName = "Product 003",
                ProductCode = "P03",
                Price = 300,
                StockDate = Timestamp.FromDateTime(stockDate)
            };
            var result = new ProductList();
            result.Products.Add(product1); result.Products.Add(product2); result.Products.Add(product3);
            return Task.FromResult(result);
        }
    }
}
