using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WebAdmin.App_Start;

[assembly: OwinStartup(typeof(WebAdmin.Startup))]

namespace WebAdmin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            EnumConfig.Start();
        }
    }
}
