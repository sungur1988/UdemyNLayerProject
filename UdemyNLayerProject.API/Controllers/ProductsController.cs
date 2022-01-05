using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.DTOs;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        public ProductsController(IProductService productService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpGet("getbyprice")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByPrice(decimal maxPrice,decimal minPrice)
        {
            var products = await _productService.Where(x => x.Price < maxPrice && x.Price > minPrice);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Ok(_mapper.Map<ProductDto>(product));
        }


        [ValidationFilter]
        [HttpPut]
        public  IActionResult UpdateProduct(ProductDto productDto)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();

        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetProductWithCategory(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
    }
}
