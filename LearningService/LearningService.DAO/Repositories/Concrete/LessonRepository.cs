using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Concrete
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}