using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_27_DoDinhTuan_DHTI15A1CL_21103100756_M27.Startup))]
namespace _27_DoDinhTuan_DHTI15A1CL_21103100756_M27
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
