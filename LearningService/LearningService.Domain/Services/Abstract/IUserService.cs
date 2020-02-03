using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IUserService
    {
        IEnumerable<CourseDTO> Get();
        CourseDTO Get(int id);
    }
}