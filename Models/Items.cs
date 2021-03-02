using System.ComponentModel.DataAnnotations;

namespace FacSystemPropietaria.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Precio por unidad")]
        [DataType(DataType.Currency)]
        public float? Price { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Range(0, int.MaxValue, ErrorMessage = "Favor ingresar una cantidad valida")]
        public int Quantity { get; set; }
        
        [Display(Name = "Fecha de creacion")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string CreationDate { get; set; }

        [Display(Name = "Estado")]
        public bool State { get; set; }
    }
}