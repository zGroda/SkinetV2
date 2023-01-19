using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository, 
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var specification = new ProductsWithTypesAndBrandsSpecification();
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(await _productRepository.ListWithSpecificationAsync(specification)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            //First we go for our Specifications and Criteria
            //After that we go for get our entity and combine our query, includes and criteria to get a response from DB and a result
            //All that ends with a map from Product to ProductToReturnDto as final result
            return Ok(_mapper.Map<Product, ProductToReturnDto>(await _productRepository.GetEntityWithSpecification(new ProductsWithTypesAndBrandsSpecification(id))));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
