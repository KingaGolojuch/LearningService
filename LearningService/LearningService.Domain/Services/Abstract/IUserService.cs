using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IUserService
    {
        void AddCourseSubscription(string userId, int courseId);
        void SetLessonAsCompleted(string userId, int lessonId);
    }
}