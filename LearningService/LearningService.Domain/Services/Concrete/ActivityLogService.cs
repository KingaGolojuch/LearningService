using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IUserRepository _userRepository;
        public ActivityLogService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<ActivityLogDTO> GetLogs(string userId)
        {
            var user = _userRepository.GetById(userId);
            return user.Activities.Select(x => new ActivityLogDTO
            {
                Date = x.Date,
                Description = x.Description,
                Name = x.ActivityType.Name
            });
        }
    }
}
