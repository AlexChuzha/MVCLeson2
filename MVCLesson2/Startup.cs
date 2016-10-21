using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLesson2.Startup))]
namespace MVCLesson2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
