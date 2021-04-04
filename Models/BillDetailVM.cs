using System.Collections.Generic;


namespace FacSystemPropietaria.Models
{
    public class BillDetailVM
    {
        public List<string> ItemsIds { get; set; }
        public List<string> Quantity { get; set; }
        //public List<string> Price { get; set; }
        //public string itemsForBill { get; set; }
    }
}