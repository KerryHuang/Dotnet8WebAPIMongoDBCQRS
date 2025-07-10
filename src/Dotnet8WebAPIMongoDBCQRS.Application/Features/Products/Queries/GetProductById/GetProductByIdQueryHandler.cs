using Dotnet8WebAPIMongoDBCQRS.Application.DTOs;
using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetProductById
{
    /// <summary>
    /// 處理 GetProductByIdQuery 的 Handler。
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="productRepository">產品資料倉儲。</param>
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 處理根據 ID 查詢單一產品的查詢。
        /// </summary>
        /// <param name="request">查詢請求。</param>
        /// <param name="cancellationToken">取消權杖。</param>
        /// <returns>對應的產品 DTO，若找不到則為 null。</returns>
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}