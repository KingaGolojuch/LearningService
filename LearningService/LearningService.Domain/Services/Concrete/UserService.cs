using AutoMapper;
using LearningService.DAO.CustomTypes;
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
        private readonly ILessonRepository _lessonRepository;
        public UserService(
            IUserRepository userRepository,
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
        }
        public void AddCourseSubscription(string userId, int courseId)
        {
            var user = _userRepository.GetById(userId);
            var course = _courseRepository.GetById(courseId);
            var newCourse = new UserCourseSubscription
            {
                User = user,
                Course = course
            };
            user.AddCourse(newCourse);

            if (!user.DataChanged)
                return;

            user.AddSubscription($"Dokonano subskrypcji na kurs {course.Name}", ActivityTypeCustom.CourseSubscription);
            _userRepository.Update(user);
        }

        public void LogAccountLoggedIn(string userId)
        {
            var user = _userRepository.GetById(userId);
            user.AddSubscription($"Zalogowano", ActivityTypeCustom.AccountLoggedIn);
            _userRepository.Update(user);
        }

        public void LogAccountLoggedOff(string userId)
        {
            var user = _userRepository.GetById(userId);
            user.AddSubscription($"Wylogowano", ActivityTypeCustom.AccountLogOut);
            _userRepository.Update(user);
        }

        public void LogCreatedAccount(string userId)
        {
            var user = _userRepository.GetById(userId);
            user.AddSubscription($"Utworzono konto", ActivityTypeCustom.AccountCreated);
            _userRepository.Update(user);
        }

        public void LogEditAccountData(string userId, string description)
        {
            var user = _userRepository.GetById(userId);
            user.AddSubscription(description, ActivityTypeCustom.AccountManagement);
            _userRepository.Update(user);
        }
    }
}