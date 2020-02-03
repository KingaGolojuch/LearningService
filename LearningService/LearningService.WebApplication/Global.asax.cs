using LearningService.WebApplication.Helpers.MapperProfiles;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningService.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}