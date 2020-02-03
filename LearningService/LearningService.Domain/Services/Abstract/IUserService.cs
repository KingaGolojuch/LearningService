using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IUserService
    {
        IEnumerable<TestDTO> Get();
        TestDTO Get(int id);
    }
}