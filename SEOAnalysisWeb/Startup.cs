using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEOAnalysisWeb.Startup))]
namespace SEOAnalysisWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
