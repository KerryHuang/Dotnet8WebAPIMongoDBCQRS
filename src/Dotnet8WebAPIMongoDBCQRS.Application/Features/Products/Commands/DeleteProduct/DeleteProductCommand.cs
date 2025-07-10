using MediatR;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.DeleteProduct
{
    /// <summary>
    /// 代表刪除一個產品的命令。
    /// </summary>
    public class DeleteProductCommand : IRequest<bool>
    {
        /// <summary>
        /// 要刪除的產品 ID。
        /// </summary>
        public string Id { get; set; } = null!;
    }
}