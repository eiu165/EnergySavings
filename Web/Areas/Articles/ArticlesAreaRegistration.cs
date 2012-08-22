using System.Web.Mvc;

namespace Web.Areas.Articles
{
    public class ArticlesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Articles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Articles_default",
                "Articles/{articleUrl}",
                new { controller = "Page", action = "Index", articleUrl = "" }
            ); 
            context.MapRoute(
                "Articles_default_never_get_to",
                "Articles/{controller}/{action}/{id}",
                new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
