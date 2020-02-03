﻿using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ICourseService
    {
        IEnumerable<CourseDTO> Get();
        CourseDTO Get(int id);
        void Add(CourseDTO course);
    }
}