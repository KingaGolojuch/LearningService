using LearningService.Domain.Services.Abstract;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LearningService.Domain.Services.Concrete
{
    public class CompilationService : ICompilationService
    {
        public IEnumerable<string> CheckCodeCorrectness(string code, IEnumerable<string> requiredNames)
        {
            try
            {
                var errorList = new List<string>();
                MethodInfo templateFunction = CreateFunctionVoid(code);
                if (requiredNames.Any())
                {
                    code = code.ToUpper();
                    foreach (var requiredName in requiredNames)
                    {
                        if (code.Contains(requiredName.ToUpper()))
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

        public IEnumerable<string> CheckCodeCorrectness(string code, string answer, IEnumerable<string> requiredNames)
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
                    code = code.ToUpper();
                    foreach (var requiredName in requiredNames)
                    {
                        if (code.Contains(requiredName.ToUpper()))
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

        private static MethodInfo CreateFunctionVoid(string userFunction)
        {
            string code = @"
                using System;
            
                namespace UserFunctions
                {                
                    public class BinaryFunction
                    {                
                        public static void Function()
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
