using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(GoPlanAPI.Startup))]

namespace GoPlanAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
