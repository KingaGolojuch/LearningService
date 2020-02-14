using LearningService.DAO.Entities;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface ILessonRepository
    {
        Lesson GetById(int lessonId);
        IEnumerable<Lesson> GetLessons(int courseId);
        void Add(Lesson entity);
        void Update(Lesson entity);
    }
}