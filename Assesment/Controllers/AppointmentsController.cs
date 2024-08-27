using Assesment.Models;
using Assesment.Repository;
using Assesment.Repository.IRepository;
using EmailSmtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
namespace Assesment.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly ISmtpEmail _smtpEmailService;
        private readonly IConfiguration _configuration;


        public AppointmentsController(ProductRepository productRepository, AppointmentRepository appointmentRepo, GmailSMTPEmail gmailSMTP, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _appointmentRepository = appointmentRepo;
            _smtpEmailService = gmailSMTP;
            _configuration = configuration;
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
        [ValidateAntiForgeryToken]
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
                //Send Email
                if(appointment.Appoint.Email != null || appointment.Appoint.Email != "")
                {
                    _smtpEmailService.ToEmail = appointment.Appoint.Email;
                    _smtpEmailService.FromEmail = _configuration.GetValue<string>("Email:EmailAddress");
                    _smtpEmailService.Port = 587;
                    _smtpEmailService.FromPassword = _configuration.GetValue<string>("Email:Password");
                    _smtpEmailService.includeSubject("Appointment with XXXX Insurance Brokers(" + appointment.Appoint.Date.ToString() + ")");
                    _smtpEmailService.includeBody(string.Format("Hello {0} {1}, This is an email confirmation of your Appointment with XXXX Insurance on {2}", appointment.Appoint.Name, appointment.Appoint.Surname, appointment.Appoint.Date));
                    _smtpEmailService.sendEmail();
                }

                return RedirectToAction("Index","Home");
            }
            IEnumerable<SelectListItem> productList = _productRepository.GetAll().Select(product => new SelectListItem { Text = product.Name, Value = product.Id.ToString() });
            return View(new AppointmentVM { Appoint = appointment.Appoint, ProductList = productList });
        }
    }
}
