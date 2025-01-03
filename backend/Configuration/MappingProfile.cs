using AutoMapper;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace backend.Configuration
{
    public class MappingProfile : Profile {

        public MappingProfile(){
            CreateMap<Admins, AdminDTO>();

            CreateMap<Applications, ApplicationsDTO>()
                .ForMember(d => d.User, opt => opt.MapFrom(src => src.User))
                .ForMember(d => d.JobId, opt => opt.MapFrom(src => src.JobOffer !=null ? src.JobOffer.JobId : 0))
                .ForMember(d => d.JobTitle, opt => opt.MapFrom(src => src.JobOffer != null ? src.JobOffer.Title : ""));

            CreateMap<Companies, CompaniesDTO>();
       
            CreateMap<Competencies, CompetenciesDTO>();

            CreateMap<Experiences, ExperiencesDTO>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.UserId : 0))
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.LastName : ""))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : ""));

            CreateMap<Formations, FormationsDTO>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.UserId : 0))
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.LastName : ""))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : ""));

            CreateMap<Joboffer, JobofferDTO>()
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(src => src.Company != null ? src.Company.CompanyId : 0))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.Name : ""))
                .ForMember(d => d.Applications, opt => opt.MapFrom(src => src.Applications));

            CreateMap<UserCompetencies, UserCompetenciesDTO>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.UserId : 0))
                .ForMember(d => d.CompetencyId, opt => opt.MapFrom(src => src.Competency != null ? src.Competency.CompetencyId : 0))
                .ForMember(d => d.CompetencyName, opt => opt.MapFrom(src => src.Competency != null ? src.Competency.Name : ""));
                
            CreateMap<Users, UserDTO>()
                .ForMember(d => d.AppCollection, opt => opt.MapFrom(src => src.Applications))
                .ForMember(d => d.UserCompetencies, opt => opt.MapFrom(src => src.UserCompetencies))
                .ForMember(d => d.Formations, opt => opt.MapFrom(src => src.Formations))
                .ForMember(d => d.Experiences, opt => opt.MapFrom(src => src.Experiences));


        }

    }
}