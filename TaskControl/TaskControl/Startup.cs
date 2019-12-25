using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskControl.Startup))]
namespace TaskControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
