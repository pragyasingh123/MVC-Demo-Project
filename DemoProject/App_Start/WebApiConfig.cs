using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
           
          
            config.Routes.MapHttpRoute("Register",
                                    "api/user/registration",
                                    new { controller = "UserRegistrationFromAngular", action = "UserRegister", id = RouteParameter.Optional });


            config.Routes.MapHttpRoute("Login",
                                 "api/user/login",
                                 new { controller = "UserRegistrationFromAngular", action = "UserLogin", id = RouteParameter.Optional });
        }
    }
}
