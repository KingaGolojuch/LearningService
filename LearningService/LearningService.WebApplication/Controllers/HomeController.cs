using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("StartPageUnloggeUser");

            return View();
        }
    }
}