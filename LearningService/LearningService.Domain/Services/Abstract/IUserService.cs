using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IUserService
    {
        void AddCourseSubscription(string userId, int courseId);
        void LogCreatedAccount(string userId);
        void LogAccountLoggedIn(string userId);
        void LogAccountLoggedOff(string userId);
        void LogEditAccountData(string userId, string description);
    }
}