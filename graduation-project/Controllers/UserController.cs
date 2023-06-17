using graduation_project.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graduation_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        private readonly ILogger<UserController> _logger;
        private readonly DataContext dataContext;

        public UserController(ILogger<UserController> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(UserDto dto)
        {
            var user = graduation_project.Entities.User.CreateUser(dto.UserName, dto.Password, dto.Email, dto.PhoneNumber);


            await dataContext.User.AddAsync(user);
            var rowEfected = await dataContext.SaveChangesAsync();
            if (rowEfected > 0)
            {
                return Ok(user.UserGuid);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("Users")]
        public async Task<ActionResult> Users()
        {
            return Ok(await dataContext.User.Select(a => new UserDto
            {
                Email = a.Email,
                Guid = a.UserGuid,
                Password = a.Password,
                PhoneNumber = a.PhoneNumber,
                UserName = a.UserName
            }).ToListAsync());
        }


        [HttpGet("Login")]
        public async Task<ActionResult> Login(string userName, string password)
        {
            var user = await dataContext.User.FirstOrDefaultAsync(a => a.UserName == userName.TrimStart().TrimEnd());

            if (user is null)
            {
                return BadRequest("User Not Found");
            }
            else
            {
                if (user.Password == password)
                    return Ok(user.UserGuid);
                else
                    return BadRequest("Password Invalid");
            }
        }
    }
}
