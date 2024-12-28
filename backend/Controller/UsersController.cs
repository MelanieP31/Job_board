
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("/api/users")]
    public class UsersController : ControllerBase {
        private readonly UsersService _userService;

        public UsersController(UsersService userService){
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