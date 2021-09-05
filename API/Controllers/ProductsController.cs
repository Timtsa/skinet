using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
         IGenericRepository<ProductType> productTypeRepo,
         IMapper mapper)
        {
            this._productRepo = productRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productPurams)
        {
            var spec =new ProductsWithTypesAndBrandsSrecification(productPurams);
            var specCount=new ProductWithFiltersForCountSpecification(productPurams);
            var totalItems = await _productRepo.CountAsync(specCount); 
            var products = await _productRepo.ListAsync(spec);

            var data= _mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok( new Pagination<ProductToReturnDto>(productPurams.PageIndex,productPurams.PageSize,totalItems,
            data));          
            
            
        }

        [HttpGet("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiRespons), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec =new ProductsWithTypesAndBrandsSrecification(id);
            var product= await _productRepo.GetEntityWithSpec(spec);
            if(product==null) return NotFound(new ApiRespons(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
           var productBrands= await _productBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
           var productTypes= await _productTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }




    }
}