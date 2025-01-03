using AutoMapper;
using backend.Configuration;
using backend.DTO;
using backend.Models;

namespace backend.Services
{
    public class AdminService{

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public AdminService(JobBoardContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public AdminDTO? GetAdminById(int id){

            var admin = _context.Admins.FirstOrDefault(u => u.AdminId == id);
            
            if(admin == null) {
                throw new Exception ("Admin not found");
            }

            return _mapper.Map<AdminDTO>(admin);
        }
        
    }
}