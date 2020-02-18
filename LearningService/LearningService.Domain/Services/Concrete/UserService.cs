﻿using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        public UserService(
            IUserRepository userRepository,
            ICourseRepository courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }
        public void AddCourseSubscription(string userId, int courseId)
        {
            var user = _userRepository.GetById(userId);
            //var newCourse = new UserCourseSubscription
            //{
            //    User = new User { Id = userId },
            //    Course = new Course { Id = courseId }
            //};
            var newCourse = new UserCourseSubscription
            {
                User = user,
                Course = _courseRepository.GetById(courseId)
            };
            user.AddCourse(newCourse);

            _userRepository.Update(user);
        }
    }
}