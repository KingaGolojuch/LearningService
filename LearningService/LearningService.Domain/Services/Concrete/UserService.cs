using AutoMapper;
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
            var newCourse = new UserCourseSubscription
            {
                User = user,
                Course = new Course { Id = courseId }
            };
            user.AddCourse(newCourse);

            if (!user.DataChanged)
                return;

            user.AddSubscription("dodałeś subskrypcję", 1);
            _userRepository.Update(user);
        }
        
        public void SetLessonAsCompleted(string userId, int lessonId)
        {
            var user = _userRepository.GetById(userId);
            var passedLesson = new UserLesson
            {
                User = user,
                Lesson = new Lesson { Id = lessonId }
            };
            user.AddLesson(passedLesson);

            if (!user.DataChanged)
                return;

            _userRepository.Update(user);
        }
    }
}