using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class SharpCodeController : BaseController
    {
        // GET: SharpCode
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestSharpCodeViewModel model)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            CompilerParameters parameters =
            new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll"})
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };
            parameters.GenerateExecutable = true;
            var compilecode = 
                @"
                    using System;

                    namespace HelloWorld
                    {
                        class HelloWorldClass
                        {
                            static void Main(string[] args)
                            {
                                Console.ReadLine();
                            }
                        }
                    }
                ";
            compilecode = compilecode.Replace("Console.ReadLine()", model.Name);
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, compilecode);
           // CompilerResults results = icc.CompileAssemblyFromSource(parameters, model.Name);
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError compilerError in results.Errors)
                {
                    var message = $"Line number: {compilerError.Line}. Error number: {compilerError.ErrorNumber}. Error message: {compilerError.ErrorNumber}. {Environment.NewLine}";
                    ModelState.AddModelError(string.Empty, message);
                }
                return View(model);
            }
            return View(model);
        }
    }
}