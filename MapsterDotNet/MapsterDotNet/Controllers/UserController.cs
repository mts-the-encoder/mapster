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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            var user = model.Adapt<User>();
            _context.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context
                .Users
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context
                .Users
                .Where(x => x.Id == id)
                .ProjectToType<UserModel>()
                .ToListAsync();

            return Ok(response);
        }
    }
}
