
namespace FacSystemPropietaria.Models
{
    public class BillDetails
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}