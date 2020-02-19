using AutoMapper;
using LearningService.WebApplication.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<int, SelectListItem>()
                .ForMember(
                    dest => dest.Value, 
                    opt => opt.MapFrom(src => src)
                ).ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src.ToString())
                );
        }
    }
}