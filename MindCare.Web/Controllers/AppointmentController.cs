using Microsoft.AspNetCore.Mvc;

namespace MindCare.Web.Controllers
{
    public class AppointmentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
