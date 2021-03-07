using System.Collections.Generic;

namespace FacSystemPropietaria.Models
{
    public class NewItemsViewModel
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}