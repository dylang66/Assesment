using Assesment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookAppointment(Appointment apointment)
        {
            if (apointment == null)
            {
                return View();
            }
            return View();
        }
    }
}
