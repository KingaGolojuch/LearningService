using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.Domain
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Name,
                   opt => opt.MapFrom(src => src.Name)
                )
                .ReverseMap()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Name,
                   opt => opt.MapFrom(src => src.Name)
                );
        }
    }
}