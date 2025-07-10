namespace Dotnet8WebAPIMongoDBCQRS.Application.DTOs
{
    /// <summary>
    /// 代表產品的資料傳輸物件 (DTO)。
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// 產品的唯一識別碼。
        /// </summary>
        public string Id { get; set; } = null!;

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