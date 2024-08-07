using Assesment.Models;
using Assesment.Repository;
using Assesment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assesment.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Appointment> _appointmentRepository;
        public AppointmentsController(ProductRepository productRepository, AppointmentRepository appointmentRepo)
        {
            _productRepository = productRepository;
            _appointmentRepository = appointmentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookAppointment()
        {
            IEnumerable<SelectListItem> productList = _productRepository.GetAll().Select(product => new SelectListItem { Text = product.Name, Value = product.Id.ToString()});
            return View(new AppointmentVM {Appoint = new Appointment { Date=DateTime.Now}, ProductList = productList});
        }

        [HttpPost]
        public IActionResult BookAppointment(AppointmentVM appointment)
        {
            //Validation check if email or mobile is entered correctly
            if(appointment.Appoint.MobileNumber == null && appointment.Appoint.Email == null)
            {
                ModelState.AddModelError("Appoint.Email", "An email or a mobile number is required");
                ModelState.AddModelError("Appoint.MobileNumber", "An email or a mobile number is required");
            }
            //Check if date is further then today
            if (appointment.Appoint.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Appoint.Date", "Date must be in the future");
            }
            if (appointment.Appoint.ProductId ==  null || appointment.Appoint.ProductId == 0)
            {
                ModelState.AddModelError("Appoint.ProductId", "A product must be selected");
            }
            if (ModelState.IsValid)
            {
                //User validated 
                //Add Apointment to Database
                _appointmentRepository.Add(appointment.Appoint);
                _appointmentRepository.Save();
                return RedirectToAction("Home");
            }
            IEnumerable<SelectListItem> productList = _productRepository.GetAll().Select(product => new SelectListItem { Text = product.Name, Value = product.Id.ToString() });
            return View(new AppointmentVM { Appoint = appointment.Appoint, ProductList = productList });
        }
    }
}
