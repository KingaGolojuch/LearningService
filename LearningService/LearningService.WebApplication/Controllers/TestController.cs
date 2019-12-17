using LearningService.Domain.Services.Abstract;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            this._testService = testService;
        }
        // GET: Test
        public ActionResult Index()
        {
            var model = _testService.Get();
            return View(model);
        }
    }
}