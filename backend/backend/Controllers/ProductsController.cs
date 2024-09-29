using backend.Data.Models;
using backend.Data.Repositories.Interfaces;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository) { 
            _productRepository = productRepository;
                
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _productRepository.GetAllProductsAsync().Result;
            return Ok(response);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            // Validate if 'id' is a valid MongoDB ObjectId
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest("Invalid MongoDB ObjectId format.");
            }

            try
            {
                var response = _productRepository.GetProductByIdAsync(id).Result;

                if (response == null)
                {
                    return NoContent();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var data = _productRepository.GetProductByIdAsync(id).Result;
            if (data is null)
            {
                return BadRequest("El producto no existe");
            }
            var response = _productRepository.DeleteProductAsync(id).Result;
            return Ok(response);
        }


        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDTO request){
            var newProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = Convert.ToDecimal(request.Price),
                Category = request.Category,
                Stock = Convert.ToInt32(request.Stock),
                Image = request.Image,
            };

            _productRepository.CreateProductAsync(newProduct).Wait();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateProductDTO request)
        {
            // Obtener el producto por ID
            var data = await _productRepository.GetProductByIdAsync(id);

            if (data is null)
            {
                return NotFound("El producto no existe");
            }

            // Actualizar los campos del producto
            data.Name = request.Name;
            data.Description = request.Description;
            data.Price = Convert.ToDecimal(request.Price);
            data.Category = request.Category;
            data.Image = request.Image;
            data.Stock = Convert.ToInt32(request.Stock);

            // Actualizar el producto en la base de datos
            await _productRepository.UpdateProductAsync(id, data); 

            return Ok(data); 
        }
    }
}
