using MediatR;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.CreateProduct
{
    /// <summary>
    /// 代表建立一個新產品的命令。
    /// </summary>
    public class CreateProductCommand : IRequest<string>
    {
        /// <summary>
        /// 產品名稱。
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 產品描述。
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 產品價格。
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 庫存數量。
        /// </summary>
        public int Stock { get; set; }
    }
}