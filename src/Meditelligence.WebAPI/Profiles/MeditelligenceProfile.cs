﻿using AutoMapper;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;

namespace Meditelligence.WebAPI.Profiles
{
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

        }
    }
}