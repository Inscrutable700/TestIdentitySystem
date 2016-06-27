using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TIS.Business;

namespace TestIdentitySystem.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            BusinessContext businessContext = this.Request.GetOwinContext().Get<BusinessContext>();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}