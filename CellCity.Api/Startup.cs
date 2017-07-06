using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CellCity.Api.Startup))]

namespace CellCity.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Web.Http.HttpConfiguration config = new System.Web.Http.HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
