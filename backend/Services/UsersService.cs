
using AutoMapper;
using backend.Configuration;
using backend.Models;
using backend.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UsersService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public UsersService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GetAllUser
        public List<UserDTO> GetAllUsers()
        {
            var users= _context.Users
                .Include(u => u.Applications)
                .Include(u => u.UserCompetencies)
                    .ThenInclude(uc => uc.Competency)
                .Include(u => u.Formations)
                .Include(u => u.Experiences)
                .ToList();
            return _mapper.Map<List<UserDTO>>(users);
        }

        //GetUserById
        public UserDTO GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<Users>(userDTO);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, Users newUser)
        {
            var existingUser = _context.Users.FirstOrDefault(a => a.UserId == id);
            if (existingUser != null)
            {
                _context.Users.Update(newUser);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"User {id} not found");
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}