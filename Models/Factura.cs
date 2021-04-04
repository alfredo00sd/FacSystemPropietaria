
using System.Collections.Generic;

namespace FacSystemPropietaria.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public string FacDate { get; set; }
        public string FacComment { get; set; }
        public List<Items> FacItem { get; set; } 
    }
}