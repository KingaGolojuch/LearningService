using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.Enums;
using LearningService.Domain.Exceptions;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using System;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class CompilationService : ICompilationService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserRepository _userRepository;

        public CompilationService(
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository,
            IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
        }

        public void CompileCode(string code)
        {
            try
            {
                MethodInfo templateFunction = CreateFunctionString(code);
                var userCodeFunction = (Func<string>)Delegate.CreateDelegate(typeof(Func<string>), templateFunction);
                string result = userCodeFunction();
            }
            catch (InvalidOperationException ex)
            {
                var results = ex.Message;
            }
        }

        public IEnumerable<string> IsResultValid(string code, IEnumerable<string> requiredNames)
        {
            try
            {
                var errorList = new List<string>();
                MethodInfo templateFunction = CreateFunctionString(code);
                var userCodeFunction = (Func<Object>)Delegate.CreateDelegate(typeof(Func<Object>), templateFunction);
                string result = userCodeFunction().ToString();
                if (requiredNames.Any())
                {
                    foreach (var requiredName in requiredNames)
                    {
                        if (code.Contains(requiredName))
                            continue;

                        errorList.Add($"Brakuje {requiredName}");
                    }
                }

                return errorList;
            }
            catch (InvalidOperationException ex)
            {
                return new List<string>() { ex.Message };
            }
        }

        public IEnumerable<string> IsResultValid(string code, string answer, IEnumerable<string> requiredNames)
        {
            try
            {
                var errorList= new List<string>();
                MethodInfo templateFunction = CreateFunctionString(code);
                var userCodeFunction = (Func<Object>)Delegate.CreateDelegate(typeof(Func<Object>), templateFunction);
                string result = userCodeFunction().ToString();
                if (result != answer)
                {
                    errorList.Add("Niepoprawny wynik");
                    return errorList;
                }
                if (requiredNames.Any())
                {
                    foreach (var requiredName in requiredNames)
                    {
                        if (code.Contains(requiredName))
                            continue;

                        errorList.Add($"Brakuje {requiredName}");
                    }
                }

                return errorList;
            }
            catch (InvalidOperationException ex)
            {
                return new List<string>() { ex.Message };
            }
        }

        private static MethodInfo CreateFunctionString(string userFunction)
        {
            string code = @"
                using System;
            
                namespace UserFunctions
                {                
                    public class BinaryFunction
                    {                
                        public static Object Function()
                        {
                            userCode;
                        }
                    }
                }
            ";

            string finalCode = code.Replace("userCode", userFunction);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), finalCode);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Type binaryFunction = results.CompiledAssembly.GetType("UserFunctions.BinaryFunction");
            return binaryFunction.GetMethod("Function");
        }
    }
}
