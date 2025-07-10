using Dotnet8WebAPIMongoDBCQRS.Application.DTOs;
using MediatR;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetProductById
{
    /// <summary>
    /// 代表根據 ID 查詢單一產品的查詢。
    /// </summary>
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        /// <summary>
        /// 要查詢的產品 ID。
        /// </summary>
        public string Id { get; set; } = null!;
    }
}