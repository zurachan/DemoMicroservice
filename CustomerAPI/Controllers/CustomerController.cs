using AutoMapper;
using CustomerAPI.Domain;
using CustomerAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;
        public CustomerController(CustomerDbContext context, IMapper mapper)
        {
            _context = context; ;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(_mapper.Map<List<Customer>, List<CustomerDto>>(customers));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var entity = _mapper.Map<Customer>(model);
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CustomerDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var entity = _mapper.Map<Customer>(model);
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return BadRequest();
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
