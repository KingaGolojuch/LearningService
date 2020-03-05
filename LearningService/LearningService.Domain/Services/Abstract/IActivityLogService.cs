using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IActivityLogService
    {
        IEnumerable<ActivityLogDTO> GetLogs(string userId);
    }
}
