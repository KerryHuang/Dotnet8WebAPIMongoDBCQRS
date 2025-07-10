using Dotnet8WebAPIMongoDBCQRS.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.DeleteProduct
{
    /// <summary>
    /// 處理 DeleteProductCommand 的 Handler。
    /// </summary>
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="productRepository">產品資料倉儲。</param>
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 處理刪除產品的命令。
        /// </summary>
        /// <param name="request">刪除產品的命令。</param>
        /// <param name="cancellationToken">取消權杖。</param>
        /// <returns>如果刪除成功則為 true，否則為 false。</returns>
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteAsync(request.Id);
        }
    }
}