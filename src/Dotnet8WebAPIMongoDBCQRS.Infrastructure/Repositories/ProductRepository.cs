using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using Dotnet8WebAPIMongoDBCQRS.Domain.Entities;
using Dotnet8WebAPIMongoDBCQRS.Infrastructure.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Infrastructure.Repositories
{
    /// <summary>
    /// 產品資料倉儲的 MongoDB 實現。
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="context">MongoDB 資料庫上下文。</param>
        public ProductRepository(MongoDbContext context)
        {
            _products = context.Products;
        }

        /// <inheritdoc />
        public async Task AddAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _products.DeleteOneAsync(p => p.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _products.Find(p => true).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Product?> GetByIdAsync(string id)
        {
            return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(Product product)
        {
            var result = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}