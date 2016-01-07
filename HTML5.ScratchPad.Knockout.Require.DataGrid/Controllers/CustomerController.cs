using System.Web.Mvc;

namespace HTML5.ScratchPad.Knockout.Require.DataGrid.Controllers
{
    public class CustomerController : Controller
    {
        //Error need to add this in header("Access-Control-Allow-Origin: http://localhost:2000");
        //Check console in chrome tools
        //XMLHttpRequest cannot load http://localhost:2000/api/customer/. No 'Access-Control-Allow-Origin' header is present on the requested resource. Origin 'http://localhost:6586' is therefore not allowed access.

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}