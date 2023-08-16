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
        }
    }
}
