using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.Enums;
using LearningService.Domain.Exceptions;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class CompilationService : ICompilationService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserRepository _userRepository;

        public CompilationService(
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository,
            IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
        }

    }
}
