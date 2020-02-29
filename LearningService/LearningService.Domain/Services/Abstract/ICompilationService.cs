using LearningService.Domain.Enums;
using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ICompilationService
    {
        IEnumerable<string> CheckCodeCorrectness(string code, IEnumerable<string> requiredNames);
        IEnumerable<string> CheckCodeCorrectness(string code, string answer, IEnumerable<string> requiredNames);
    }
}
