using System.ComponentModel.DataAnnotations;

namespace FacSystemPropietaria.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Nombre comercial o razon social")]
        //[StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Comercial_name_or_social_reason { get; set; }
        
        //[Required]
        [Display(Name = "RNC o Cedula")]
        //[StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        public string RNC_or_cedula { get; set; }

        //[Required]
        [Display(Name = "Cuenta contable")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Accountable_account { get; set; }

        [Display(Name = "Estado")]
        public bool State { get; set; }
    }
}