using Dotnet8WebAPIMongoDBCQRS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Interfaces
{
    /// <summary>
    /// 定義產品資料倉儲的合約。
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 異步取得所有產品。
        /// </summary>
        /// <returns>產品列表。</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// 根據 ID 異步取得單一產品。
        /// </summary>
        /// <param name="id">產品 ID。</param>
        /// <returns>對應的產品，若找不到則為 null。</returns>
        Task<Product?> GetByIdAsync(string id);

        /// <summary>
        /// 異步新增一個產品。
        /// </summary>
        /// <param name="product">要新增的產品。</param>
        /// <returns>完成的 Task。</returns>
        Task AddAsync(Product product);

        /// <summary>
        /// 異步更新一個產品。
        /// </summary>
        /// <param name="product">要更新的產品。</param>
        /// <returns>如果更新成功則為 true，否則為 false。</returns>
        Task<bool> UpdateAsync(Product product);

        /// <summary>
        /// 根據 ID 異步刪除一個產品。
        /// </summary>
        /// <param name="id">要刪除的產品 ID。</param>
        /// <returns>如果刪除成功則為 true，否則為 false。</returns>
        Task<bool> DeleteAsync(string id);
    }
}