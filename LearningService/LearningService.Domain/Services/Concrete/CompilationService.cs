using LearningService.Domain.Services.Abstract;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace LearningService.Domain.Services.Concrete
{
    public class CompilationService : ICompilationService
    {
        public IEnumerable<string> CheckCodeCorrectness(string code, IEnumerable<string> requiredNames)
        {
            try
            {
                if (code.ToUpper().Contains("RETURN"))
                    return new List<string>() { "Metoda nie może posiadać polecenia return" };

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
                if (!code.ToUpper().Contains("RETURN"))
                    return new List<string>() { "Metoda musi posiadać polecenie return" };

                var countOfReturnMethods = Regex.Matches(code.ToUpper(), "RETURN").Count;
                if (countOfReturnMethods > 1)
                    return new List<string>() { "Metoda może posiadać tylko jedno polecenie return" };

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
            
                namespace LearningService
                {                
                    public class Compilation
                    {                
                        public static Object CheckCode()
                        {
                            userCode
                        }
                    }
                }
            ";

            string finalCode = code.Replace("userCode", userFunction);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                WarningLevel = 4
            };
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, finalCode);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format($"Numer wiersza: {error.Line - 9}. Kod błędu: {error.ErrorNumber}. Treść: {error.ErrorText}."));
                }

                throw new InvalidOperationException(sb.ToString());
            }
            if (results.Errors.HasWarnings)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format($"Numer wiersza: {error.Line - 9}. Kod błędu: {error.ErrorNumber}. Treść: {error.ErrorText}."));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Type binaryFunction = results.CompiledAssembly.GetType("LearningService.Compilation");
            return binaryFunction.GetMethod("CheckCode");
        }

        private static MethodInfo CreateFunctionVoid(string userFunction)
        {
            string code = @"
                using System;
            
                namespace LearningService
                {                
                    public class Compilation
                    {                
                        public static void CheckCode()
                        {
                            userCode
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
                    sb.AppendLine(String.Format($"Numer wiersza: {error.Line - 9}. Kod błędu: {error.ErrorNumber}. Treść: {error.ErrorText}."));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Type binaryFunction = results.CompiledAssembly.GetType("LearningService.Compilation");
            return binaryFunction.GetMethod("CheckCode");
        }
    }
}
