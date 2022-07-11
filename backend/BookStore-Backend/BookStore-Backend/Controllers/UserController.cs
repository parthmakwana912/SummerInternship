using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_1.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {

            return Ok(_repository.GetUsers());
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
           User user = _repository.Login(model);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
