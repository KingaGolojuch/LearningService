using AutoMapper;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly ITestRepository _testRepository;

        public UserService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public IEnumerable<TestDTO> Get()
        {
            var entities = _testRepository.Get();
            return Mapper.Map<IEnumerable<TestDTO>>(entities);
        }

        public TestDTO Get(int id)
        {
            var entity = _testRepository.GetById(id);
            return new TestDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Accepted = entity.Accepted
            };
        }
    }
}