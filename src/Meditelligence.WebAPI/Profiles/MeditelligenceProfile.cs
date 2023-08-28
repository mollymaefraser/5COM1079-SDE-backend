using AutoMapper;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using System.Diagnostics.CodeAnalysis;

namespace Meditelligence.WebAPI.Profiles
{
    [ExcludeFromCodeCoverage]
    public class MeditelligenceProfile : Profile
    {
        public MeditelligenceProfile()
        {
            // Source -> Target

            //Symptom
            CreateMap<Symptom, SymptomReadDto>()
                .ForMember(dest => dest.SymptomName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SymptomDescription, opt => opt.MapFrom(src => src.Description));
            CreateMap<SymptomCreateDto, Symptom>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SymptomName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SymptomDescription));

            //Illness
            CreateMap<Illness, IllnessReadDto>()
                .ForMember(dest => dest.IllnessName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IllnessAdvice, opt => opt.MapFrom(src => src.Advice))
                .ForMember(dest => dest.IllnessDescription, opt => opt.MapFrom(src => src.Description));
            CreateMap<IllnessCreateDto, Illness>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IllnessName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.IllnessDescription))
                .ForMember(dest => dest.Advice, opt => opt.MapFrom(src => src.IllnessAdvice));

            //Location
            CreateMap<Location, LocationReadDto>();
            CreateMap<LocationCreateDto, Location>();

            //Service
            CreateMap<Service, ServiceReadDto>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ServiceDescription, opt => opt.MapFrom(src => src.Description));
            CreateMap<ServiceCreateDto, Service>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ServiceDescription));

            // User
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.IsUserAdmin, opt => opt.MapFrom(src => src.IsAdmin));
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.UserLastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.UserPassword));
            
        }
    }
}
