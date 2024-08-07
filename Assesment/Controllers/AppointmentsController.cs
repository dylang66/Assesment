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
        public AppointmentsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookAppointment()
        {
            IEnumerable<SelectListItem> productList = _productRepository.GetAll().Select(product => new SelectListItem { Text = product.Name, Value = product.Id.ToString()});
            return View(new AppointmentVM {Appointment = new Appointment(), ProductList = productList});
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
