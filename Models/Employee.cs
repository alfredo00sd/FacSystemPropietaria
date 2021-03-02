using System.ComponentModel.DataAnnotations;

namespace FacSystemPropietaria.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        public string Cedula { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Area de trabajo")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
        
        [Display(Name = "Fecha de ingreso")]
        public string Creation_date { get; set; }

        [Required]
        [Display(Name = "% por comission")] //Cambiar a Commission 
        [Range(0, 100, ErrorMessage = "Favor ingresar {0} valido")]
        public string Commision_percentage { get; set; }

        [Display(Name = "Estado")]
        public bool State { get; set; }
    }
}