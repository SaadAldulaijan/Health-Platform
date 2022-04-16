using Health.Api.Contracts.Responses;
using Health.Api.Forms;
using Health.Data.Database;
using Health.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(DataContext ctx,
            UserManager<IdentityUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }


        [HttpGet("users")]
        public async Task<ActionResult> GetAll() => Ok(await _ctx.Users.ToListAsync());

        [HttpGet("user/{username}")]
        public async Task<ActionResult<User>> Get(string username)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Username == username);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginForm loginForm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
                return BadRequest(new AuthFailureResponse { Errors = errors });
            }

            var user = await _userManager.FindByNameAsync(loginForm.Username);
            if (user == null) return BadRequest(new AuthFailureResponse 
            { 
                Errors = new List<string>() { "username or password is not correct" }  
            });

            var authenticated = await _userManager.CheckPasswordAsync(user, loginForm.Password);

            if (!authenticated) return BadRequest(new AuthFailureResponse
            {
                Errors = new List<string>() { "username or password is not correct" }
            });

            return Ok(authenticated);
        }
    }
}
