﻿using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        public IEnumerable<CourseDTO> Get(string userId)
        {
            var entities = _courseRepository.Get(userId);
            return Mapper.Map<IEnumerable<CourseDTO>>(entities);
        }

        public CourseDTO Get(int id)
        {
            var entity = _courseRepository.GetById(id);
            return Mapper.Map<CourseDTO>(entity);
        }

        public CourseDTO Get(int id, string userId)
        {
            var entity = _courseRepository.GetById(id);
            var courseDTO = Mapper.Map<CourseDTO>(entity);
            if (courseDTO.UsersSubscribers.Any(x => x == userId))
                courseDTO.IsSubscribed = true;

            return courseDTO;
        }   

        public void Add(CourseDTO course)
        {
            var entity = Mapper.Map<Course>(course);
            _courseRepository.Add(entity);
        }

        public IEnumerable<CourseDTO> GetFromOtherUsers(string userId)
        {
            var entities = _courseRepository.Get();
            var coursesDTO = Mapper.Map<IEnumerable<CourseDTO>>(
                entities
                .Where(x => x.User.Id != userId));
            
            foreach (var course in coursesDTO)
            {
                if (course.UsersSubscribers.Any(x => x == userId))
                    course.IsSubscribed = true;
            }

            return coursesDTO;
        }
    }
}