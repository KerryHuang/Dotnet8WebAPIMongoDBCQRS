using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using Dotnet8WebAPIMongoDBCQRS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.UpdateProduct
{
    /// <summary>
    /// 處理 UpdateProductCommand 的 Handler。
    /// </summary>
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="productRepository">產品資料倉儲。</param>
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 處理更新產品的命令。
        /// </summary>
        /// <param name="request">更新產品的命令。</param>
        /// <param name="cancellationToken">取消權杖。</param>
        /// <returns>如果更新成功則為 true，否則為 false。</returns>
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);

            if (productToUpdate == null)
            {
                return false;
            }

            productToUpdate.Name = request.Name;
            productToUpdate.Description = request.Description;
            productToUpdate.Price = request.Price;
            productToUpdate.Stock = request.Stock;
            productToUpdate.UpdatedAt = System.DateTime.UtcNow;

            return await _productRepository.UpdateAsync(productToUpdate);
        }
    }
}