using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class JobOfferDAO {

        private readonly JobBoardContext _context;

        //constructeur
        public JobOfferDAO (JobBoardContext context) {
            _context = context;
        }

        //CRUD : Get all
        public List<Joboffer> GetAllJobOffer(){
            return _context.Joboffers.ToList();
        }

        //CRUD : Get One
        public Joboffer? GetJobOfferByID(int id){
            return _context.Joboffers.FirstOrDefault(u => u.JobId == id);
        }

        //CRUD : Create
        public void CreateJobOffer(Joboffer job){
            _context.Joboffers.Add(job);
            _context.SaveChanges();
        }

        //CRUD Update
        public void UpdateJobOffer(Joboffer job){
            _context.Joboffers.Update(job);
            _context.SaveChanges();
        }

        //CRUD Delete
        public void DeleteJobOffer(int id){
            var Joboffer = GetJobOfferByID(id);
            if (Joboffer != null) {
                _context.Joboffers.Remove(Joboffer);
                _context.SaveChanges();
            }
        }

    }
}