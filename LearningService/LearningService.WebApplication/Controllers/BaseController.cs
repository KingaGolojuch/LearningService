using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        protected string GetUserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }
    }
}