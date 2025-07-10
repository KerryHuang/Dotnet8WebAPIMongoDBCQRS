using Dotnet8WebAPIMongoDBCQRS.Application.DTOs;
using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetAllProducts
{
    /// <summary>
    /// 處理 GetAllProductsQuery 的 Handler。
    /// </summary>
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="productRepository">產品資料倉儲。</param>
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 處理查詢所有產品的查詢。
        /// </summary>
        /// <param name="request">查詢請求。</param>
        /// <param name="cancellationToken">取消權杖。</param>
        /// <returns>產品 DTO 的列表。</returns>
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            });
        }
    }
}