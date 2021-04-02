namespace FacSystemPropietaria.Models
{
    public class AccountSeat
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public string MType { get; set; }
        public string SeatDate { get; set; }
        public int SeatAmount { get; set; }
        public bool State { get; set; }
    }
}