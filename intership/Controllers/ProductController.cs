using AutoMapper;
using intership.Data;
using intership.DTO;
using intership.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        private readonly IMapper _mapper;


        public ProductController(IMapper mapper, IProductRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/products/{id}
        [HttpGet("/{id}")]
        public ActionResult<ProductReadDTO> GetProductById(Guid id)
        {
            var product = _repository.GetProductById(id);
            if (product != null)
            {
                return Ok(_mapper.Map<ProductReadDTO>(product));
            }
            return NotFound();
        }
        //GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDTO>> GetAllProducts()
        {
            var products = _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDTO>>(products));
        }
        //GET api/products/{keyword}
        [HttpGet("/{keyword}")]
        public ActionResult<ProductReadDTO> GetProductByKeyword(string keyword)
        {
            var product = _repository.GetProductMatching(keyword);
            if (product != null)
            {
                return Ok(_mapper.Map<ProductReadDTO>(product));
            }
            return NotFound();
        }
        //DELETE api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(product);
            return NoContent();
        }
        [HttpGet("/recent")]
        public ActionResult<ProductReadDTO> GetMostRecentProduct()
        {
            var product = _repository.GetRecentProduct();
            if (product != null)
                return Ok(_mapper.Map<ProductReadDTO>(product));
            else
                return NoContent();
        }
        [HttpGet("/oldest")]
        public ActionResult<ProductReadDTO> GetOldestProduct()
        {
            var product = _repository.GetOledestProduct();
            if (product != null)
                return Ok(_mapper.Map<ProductReadDTO>(product));
            else
                return NoContent();
        }
        [HttpPost]
        public ActionResult<ProductCreateDTO> CreateProduct(ProductCreateDTO _productCreateDTO)
        {
            var product = _mapper.Map<Product>(_productCreateDTO);
            _repository.CreateProduct(product);

            var productReadDto = _mapper.Map<ProductReadDTO>(product);
            return CreatedAtRoute(nameof(GetProductById), new { id = productReadDto.id }, productReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult<ProductUpdateDTO> UpdateProduct(Guid id, ProductUpdateDTO productUpdateDTO)
        {
            var productModelFormRepo = _repository.GetProductById(id);
            if(productModelFormRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(productUpdateDTO, productModelFormRepo);

            _repository.UpdateProduct(productModelFormRepo);

            return NoContent();
        }
    }
}
