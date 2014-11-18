using System.Web.Mvc;

namespace LeagueLeak.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Administration_default",
                url: "Administration/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "LeagueLeak.Web.Areas.Administration.Controllers" }
            );
        }
    }
}