using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using API.DTOS;
using AutoMapper;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        private const string productsRoute = "api/[controller]";
        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo, 
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productRepo = productsRepo;
            _productTypeRepo = productTypeRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToRetunDto>>>  GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications();
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToRetunDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToRetunDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToRetunDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}    


// Error handling 49 !