using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }
        public IEnumerable<TestDTO> Get()
        {
            return _testRepository.Get().Select(test => new TestDTO
            {
                Id = test.Id,
                Name = test.Name,
                Accepted = test.Accepted
            });
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