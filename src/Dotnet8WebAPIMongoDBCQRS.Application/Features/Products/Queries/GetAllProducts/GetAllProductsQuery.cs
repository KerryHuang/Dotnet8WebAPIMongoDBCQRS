using Dotnet8WebAPIMongoDBCQRS.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetAllProducts
{
    /// <summary>
    /// 代表查詢所有產品的查詢。
    /// </summary>
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}