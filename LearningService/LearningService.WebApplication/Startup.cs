using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningService.WebApplication.Startup))]
namespace LearningService.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
