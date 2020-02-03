using AutoMapper;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly ICourseRepository _testRepository;

        public UserService(ICourseRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public IEnumerable<CourseDTO> Get()
        {
            var entities = _testRepository.Get();
            return Mapper.Map<IEnumerable<CourseDTO>>(entities);
        }

        public CourseDTO Get(int id)
        {
            var entity = _testRepository.GetById(id);
            return new CourseDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}