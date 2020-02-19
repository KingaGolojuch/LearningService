using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ICourseService
    {
        IEnumerable<CourseDTO> Get(string userId);
        CourseDTO Get(int id);
        CourseDTO Get(int id, string userId);
        void Add(CourseDTO course);
        IEnumerable<CourseDTO> GetFromOtherUsers(string userId);
    }
}