using Mapster;
using MapsterDotNet.Data;
using MapsterDotNet.Entities;
using MapsterDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddressModel model)
        {
            var address = model.Adapt<Address>();
            _context.Add(address);

            await _context.SaveChangesAsync();
            return Ok(address);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _context
                .Addresses
                .ToListAsync();

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context
                .Addresses
                .Where(x => x.Id == id)
                .ProjectToType<AddressModel>()
                .ToListAsync();

            return Ok(response);
        }
    }
}
