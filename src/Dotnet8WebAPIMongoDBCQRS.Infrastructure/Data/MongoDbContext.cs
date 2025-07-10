using Dotnet8WebAPIMongoDBCQRS.Domain.Entities;
using MongoDB.Driver;

namespace Dotnet8WebAPIMongoDBCQRS.Infrastructure.Data
{
    /// <summary>
    /// 管理 MongoDB 的連線和 Collections。
    /// </summary>
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="database">MongoDB 資料庫實例。</param>
        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// 提供對 Products Collection 的存取。
        /// </summary>
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    }
}