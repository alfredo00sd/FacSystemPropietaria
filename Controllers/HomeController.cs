using FacSystemPropietaria.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FacSystemPropietaria.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.AccountSeats.Where(a => a.State == false).ToList());
        }

        [Authorize]
        public ActionResult ProcessSeat() 
        {
            float Ammount = 0f;
            string Description = "Asiento contable, correspondiente al perdiodo: " + DateTime.UtcNow.Date.Month + "-" + DateTime.UtcNow.Date.Year;
            //var billsOfThisPeriod = db.Bills.Where(b => Convert.ToDateTime(b.Fac_date) >= Convert.ToDateTime("01/04/2021") && Convert.ToDateTime(b.Fac_date) <= Convert.ToDateTime("31/04/2021")).ToList();
            var billsOfThisPeriod = db.Bills.ToList();
            foreach (var billTotal in billsOfThisPeriod)
            {
                Ammount += float.Parse(billTotal.Total);
            }

            AccountSeat accountSeat = new AccountSeat
            {
                Description = Description,
                CustomerId = 3,
                AccountNumber = 13,
                MType = "DB",
                SeatDate = "" + DateTime.UtcNow.Date,
                SeatAmount = Ammount,
                State = false
            };

            db.AccountSeats.Add(accountSeat);
            db.SaveChanges();

            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}