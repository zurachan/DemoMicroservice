using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Domains;
using ProductAPI.Dto;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(ProductDbContext context, IMapper mapper)
        {
            _context = context; ;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var customers = await _context.Products.ToListAsync();
            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(customers));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var customer = await _context.Products.FindAsync(id);
            return Ok(_mapper.Map<ProductDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var entity = _mapper.Map<Product>(model);
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ProductDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var entity = _mapper.Map<Product>(model);
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _context.Products.FindAsync(id);
            if (customer == null)
                return BadRequest();
            _context.Products.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
