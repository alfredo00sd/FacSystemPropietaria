using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacSystemPropietaria.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Display(Name = "Empleado")]
        public string Employee_Id { get; set; }

        [Display(Name = "Cliente")]
        public string Customer_Id { get; set; }

        [Display(Name = "Productos")]
        public string ItemDetailsId { get; set; }

        [Display(Name = "Fecha")]
        public string Fac_date { get; set; }

        [Display(Name = "Comentario")]
        //[StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Comment { get; set; }

        [Display(Name = "Productos")]
        public string Productos { get; set; }

        [Display(Name = "Total de factura")]
        public string Total { get; set; }

        [Display(Name = "% ITEBIS")]
        public string ITEBIS { get; set; }

        [Display(Name ="Estado (Pagada/No pagada)")]
        public bool State { get; set; }
    }
}