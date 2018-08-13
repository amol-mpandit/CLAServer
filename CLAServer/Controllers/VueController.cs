using System.Web.Mvc;
using CLAServer.Models;
using System.Web.Http.Cors;

namespace CLAServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class VueController : Controller
    {
        // GET: Vue
        public ActionResult App()
        {
            return View("App", new VueAppModel { Name = "TimeTable" });
        }
    }
}