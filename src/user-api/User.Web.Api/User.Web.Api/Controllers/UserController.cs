using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Web.Api.Services;

namespace User.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService productService)
        {
            _userService = productService;
        }

        [HttpGet("getUsers")]
        public async Task<IEnumerable<User.Sql.Context.Models.User>> GetProducts()
        {
            return await _userService.GetProducts();
        }

        [HttpGet("getUser/{id}")]
        public async Task<User.Sql.Context.Models.User?> GetProduct(Guid id)
        {
            return await _userService.GetProduct(id);
        }
    }
}
