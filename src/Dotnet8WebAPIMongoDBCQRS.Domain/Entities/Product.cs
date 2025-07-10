using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dotnet8WebAPIMongoDBCQRS.Domain.Entities
{
    /// <summary>
    /// 代表一個產品實體。
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 產品的唯一識別碼 (主鍵)。
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        /// <summary>
        /// 產品名稱。
        /// </summary>
        [BsonElement("Name")]
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

        /// <summary>
        /// 建立時間。
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 最後更新時間。
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}