
using backend.Models;
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

        [HttpGet("id/{id}")]
        public IActionResult GetUsersById(int id)
        {

            var Users = _userService.GetUserById(id);

            if (Users!= null)
            {
                return Ok(Users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddUsers([FromBody] Users user)
        {

            if (user == null)
            {
                return BadRequest("Invalid data for Users");
            }

            _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUsersById), new { id = user.UserId }, user); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsers(int id, [FromBody] Users newUsers)
        {
            _userService.UpdateUser(id, newUsers);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsers(int id)
        {
            var Users = _userService.GetUserById(id);
            if (Users == null)
            {
                return NotFound($"Users {id} not found.");
            }

            _userService.DeleteUser(id);
            return NoContent(); // 204 
        }
    }
}