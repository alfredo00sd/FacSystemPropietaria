using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacSystemPropietaria.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        public string Employee_Id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        public string Customer_Id { get; set; }

        [Display(Name = "Productos")]
        public List<Items> Items { get; set; }

        [Display(Name = "Fecha")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Fac_date { get; set; }

        [Display(Name = "Comentario")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Total de factura")]
        public string Total { get; set; }

        [Required]
        [Display(Name = "% ITEBIS")]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string ITEBIS { get; set; }
    }
}