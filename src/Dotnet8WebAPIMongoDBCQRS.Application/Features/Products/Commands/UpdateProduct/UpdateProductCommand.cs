using MediatR;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.UpdateProduct
{
    /// <summary>
    /// 代表更新一個現有產品的命令。
    /// </summary>
    public class UpdateProductCommand : IRequest<bool>
    {
        /// <summary>
        /// 要更新的產品 ID。
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// 新的產品名稱。
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 新的產品描述。
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 新的產品價格。
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 新的庫存數量。
        /// </summary>
        public int Stock { get; set; }
    }
}