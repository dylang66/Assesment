using Assesment.Models;
using Assesment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssesmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentRepository _AppointmentRepository;
        private readonly ILogger<AppointmentsController> _logger;
        public AppointmentsController(AppointmentRepository appRepo, ILogger<AppointmentsController> logger) {
            _AppointmentRepository = appRepo;
            _logger = logger;
        }
        .

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _AppointmentRepository.GetAll().ToList();
        }
    }
}
