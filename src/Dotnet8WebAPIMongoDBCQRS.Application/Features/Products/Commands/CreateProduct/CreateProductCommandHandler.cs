using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using Dotnet8WebAPIMongoDBCQRS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.CreateProduct
{
    /// <summary>
    /// 處理 CreateProductCommand 的 Handler。
    /// </summary>
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="productRepository">產品資料倉儲。</param>
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 處理建立新產品的命令。
        /// </summary>
        /// <param name="request">建立產品的命令。</param>
        /// <param name="cancellationToken">取消權杖。</param>
        /// <returns>新產品的 ID。</returns>
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            await _productRepository.AddAsync(product);

            return product.Id;
        }
    }
}