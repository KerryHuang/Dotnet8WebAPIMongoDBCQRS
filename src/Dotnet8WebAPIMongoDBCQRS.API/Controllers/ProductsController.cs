using Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.CreateProduct;
using Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.DeleteProduct;
using Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Commands.UpdateProduct;
using Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetAllProducts;
using Dotnet8WebAPIMongoDBCQRS.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotnet8WebAPIMongoDBCQRS.API.Controllers
{
    /// <summary>
    /// 提供產品相關的 API 端點。
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 建構函數。
        /// </summary>
        /// <param name="mediator">MediatR 實例。</param>
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 取得所有產品。
        /// </summary>
        /// <returns>產品列表。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// 根據 ID 取得單一產品。
        /// </summary>
        /// <param name="id">產品 ID。</param>
        /// <returns>對應的產品。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// 建立一個新產品。
        /// </summary>
        /// <param name="command">建立產品的命令。</param>
        /// <returns>新建立產品的 ID。</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, new { id = result });
        }

        /// <summary>
        /// 更新一個現有產品。
        /// </summary>
        /// <param name="id">要更新的產品 ID。</param>
        /// <param name="command">更新產品的命令。</param>
        /// <returns>No Content。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// 刪除一個產品。
        /// </summary>
        /// <param name="id">要刪除的產品 ID。</param>
        /// <returns>No Content。</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}