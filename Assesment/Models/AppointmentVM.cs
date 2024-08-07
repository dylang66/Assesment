using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Assesment.Models
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
