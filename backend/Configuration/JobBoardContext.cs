
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Configuration
{
    // :DbContext = héritage de DbContext
    public class JobBoardContext : DbContext{

        //constructeur (initié l'objet lors de sa création, injecte la configuration fournis dans Program.cs)
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options){} 

        public DbSet<Admins> Admins {get; set; }
        public DbSet<Applications> Applications {get; set;}
        public DbSet<Companies> Companies {get; set;}
        public DbSet<Competencies> Competencies {get; set;}
        public DbSet<Experiences> Experiences {get; set;}
        public DbSet<Formations> Formations {get; set;}
        public DbSet<Joboffer> Joboffer {get; set;}
        public DbSet<UserCompetencies> User_Competencies {get; set;}
        public DbSet<Users> Users {get; set;}

        //Méthode pour faire les relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relation Many-To-One
            modelBuilder.Entity<Applications>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Applications>()
                .HasOne(a => a.JobOffer)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Joboffer>()
                .HasOne(a => a.Company)
                .WithMany(h => h.JobOffers)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Experiences>()
                .HasOne(a => a.User)
                .WithMany(k => k.Experiences)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Formations>()
                .HasOne(a => a.User)
                .WithMany(l => l.Formations)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Many-To-Many : les tables de liaisons
            modelBuilder.Entity<UserCompetencies>()
                .HasKey(uc => new { uc.UserId, uc.CompetencyId });

            modelBuilder.Entity<UserCompetencies>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCompetencies)
                .HasForeignKey(uc => uc.UserId);
            
            modelBuilder.Entity<UserCompetencies>()
                .HasOne(uc => uc.Competency)
                .WithMany(u => u.UserCompetencies)
                .HasForeignKey(uc => uc.CompetencyId);
            
        }

    } 

}
