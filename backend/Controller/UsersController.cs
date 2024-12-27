
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("api/[controller]")]
    public class UserController : ControllerBase {
        private readonly UsersService _userService;

        public UserController(UsersService userService){
            _userService = userService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllUsers(){
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}