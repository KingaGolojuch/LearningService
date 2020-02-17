﻿using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.Enums;
using LearningService.Domain.ModelsDTO;
using LearningService.Helpers;
using System;

namespace LearningService.Domain.Mappers
{
    public class LessonDomainProfile : Profile
    {
        public LessonDomainProfile()
        {
            CreateMap<Lesson, LessonDTO>()
                .ForMember(
                    destination => destination.LessonType,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(LessonTypeCustom), source.LessonType.Id))
                );

            CreateMap<LessonComponent, LessonComponentDTO>();
        }
    }
}