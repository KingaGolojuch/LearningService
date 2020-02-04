using LearningService.DAO.Entities;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Get(string userId);
        Course GetById(int id);
        void Add(Course entity);
    }
}