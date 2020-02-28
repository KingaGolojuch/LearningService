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
    public class LessonService : ILessonService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserRepository _userRepository;

        public LessonService(
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository,
            IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
        }

        public void AddLessonTheory(LessonDTO lessonDTO)
        {
            var course = _courseRepository.GetById(lessonDTO.CourseId);
            
            var newLesson = new Lesson
            {
                Course = new Course { Id = lessonDTO.CourseId },
                LessonType = new LessonType { Id = (int)LessonTypeCustom.Theory },
                OrderLesson = course.GetNextOrderLesson(),
                Headline = lessonDTO.Headline,
                LessonContent = lessonDTO.LessonContent
            };
            _lessonRepository.Add(newLesson);
        }

        public void AddTheoryTest(LessonDTO lessonDTO, IEnumerable<LessonComponentDTO> components)
        {
            var course = _courseRepository.GetById(lessonDTO.CourseId);
            var validAnswer = components.Single(x => x.Selected).Name;
           
            var newLesson = new Lesson
            {
                Course = new Course { Id = lessonDTO.CourseId },
                LessonType = new LessonType { Id = (int)LessonTypeCustom.TheoryExam },
                OrderLesson = course.GetNextOrderLesson(),
                Headline = lessonDTO.Headline,
                LessonContent = lessonDTO.LessonContent,
                ValidAnswer = validAnswer
            };
            var lessonComponents = components.Select(x => new LessonComponent
            {
                Name = x.Name,
                Lesson = newLesson
            }).ToList();
            newLesson.LessonComponents = lessonComponents;
            _lessonRepository.Add(newLesson);
        }

        public void EditTheoryTest(LessonDTO lessonDTO, IEnumerable<LessonComponentDTO> components)
        {
            var lesson = _lessonRepository.GetById(lessonDTO.Id);

            lesson.SetHeadline(lessonDTO.Headline);
            lesson.SetContent(lessonDTO.LessonContent);
            var lessonComponents = components.Select(x => new LessonComponent
            {
                Id = x.Id,
                Name = x.Name,
                Lesson = lesson
            }).ToList();
            var validAnswer = components.Single(x => x.Selected).Name;
            lesson.SetComponents(lessonComponents, validAnswer);

            _lessonRepository.Update(lesson);
        }

        public void EditLessonTheory(LessonDTO lessonDTO)
        {
            var lesson = _lessonRepository.GetById(lessonDTO.Id);
            lesson.SetHeadline(lessonDTO.Headline);
            lesson.SetContent(lessonDTO.LessonContent);

            if (!lesson.DataChanged)
                return;

            _lessonRepository.Update(lesson);
        }

        public LessonDTO GetLesson(int lessonId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            return Mapper.Map<LessonDTO>(lesson);
        }

        public LessonDTO GetLesson(int lessonId, string userId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            var lessonDTO = Mapper.Map<LessonDTO>(lesson);
            lessonDTO.AlreadyPassed = lesson.IsUserPassedLesson(userId);
            return lessonDTO;
        }

        public IEnumerable<LessonComponentDTO> GetLessonOptions(int lessonId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            var lessonComponents = Mapper.Map<IEnumerable<LessonComponentDTO>>(lesson.LessonComponents);
            lessonComponents.Single(x => x.Name == lesson.ValidAnswer).Selected = true;
            return lessonComponents;
        }

        public IEnumerable<string> GetLessonRequiredNames(int lessonId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            var lessonRequiredNames = lesson.LessonComponents.Select(x => x.Name);
            return lessonRequiredNames;
        }

        public IEnumerable<LessonDTO> GetLessons(int courseId)
        {
            var lessons = _lessonRepository.GetLessons(courseId);
            return Mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        public IEnumerable<LessonDTO> GetLessons(int courseId, string userId)
        {
            var lessons = _lessonRepository.GetLessons(courseId);
            var lessonsDTO = Mapper.Map<IEnumerable<LessonDTO>>(lessons);
            foreach (var lesson in lessonsDTO)
            {
                if (lessons.Single(x => x.Id == lesson.Id).UserLessons.Any(x => x.User.Id == userId))
                    lesson.AlreadyPassed = true;
            }

            return lessonsDTO;
        }

        public void AttemptPassTheoryTest(int lessonId, int answerId, string userId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            bool answeredCorrect = lesson.IsAnswerTheoryTestCorrect(answerId);
            if (!answeredCorrect)
                throw new LessonException();

            var user = _userRepository.GetById(userId);
            user.AddLesson(lessonId);
            if (!user.DataChanged)
                return;

            _userRepository.Update(user);
        }

        public void ChangeOrderLesson(int lessonId, LessonOrderChangeDirection orderDirection)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            var course = lesson.Course;
            switch (orderDirection)
            {
                case LessonOrderChangeDirection.Down:
                    course.ChangeOrderLessonDown(lesson);
                    break;
                case LessonOrderChangeDirection.Up:
                    course.ChangeOrderLessonUp(lesson);
                    break;
                default:
                    return;
            }
            
            if (!course.DataChanged)
                return;

            _courseRepository.Update(course);
        }

        public void AddPracticalTest(LessonDTO lessonDTO, IEnumerable<string> requiredNames)
        {
            var course = _courseRepository.GetById(lessonDTO.CourseId);

            var newLesson = new Lesson
            {
                Course = new Course { Id = lessonDTO.CourseId },
                LessonType = new LessonType { Id = (int)LessonTypeCustom.PracticalExam },
                OrderLesson = course.GetNextOrderLesson(),
                Headline = lessonDTO.Headline,
                LessonContent = lessonDTO.LessonContent,
                ValidAnswer = lessonDTO.ValidAnswer
            };
            var lessonComponents = requiredNames.Select(x => new LessonComponent
            {
                Name = x,
                Lesson = newLesson
            }).ToList();

            newLesson.LessonComponents = lessonComponents;
            _lessonRepository.Add(newLesson);
        }


        public void EditPracticalTest(LessonDTO lessonDTO, IEnumerable<string> requiredNames)
        {
            var lesson = _lessonRepository.GetById(lessonDTO.Id);
            lesson.SetHeadline(lessonDTO.Headline);
            lesson.SetContent(lessonDTO.LessonContent);
            lesson.SetAnswer(lessonDTO.ValidAnswer);
            lesson.SetRequiredNames(requiredNames);

            if (lesson.DataChanged)
                _lessonRepository.Update(lesson);
        }
    }
}
