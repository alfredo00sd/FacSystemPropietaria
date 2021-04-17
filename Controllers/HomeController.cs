using FacSystemPropietaria.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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

        //Recoge los asientos para db
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

        //Busca los asientos generados en bd para enviar a WS
        //----------------------------------------------Accounting_seat -Need validations
        //Procesar/Enviar asiento contable a WS-externo
        //Recibe N/A
        //Date format : 2020-12-01
        //Busca los estatus en 0 que significa sin enviar asiento contable.
        //Notifica envio.
        public async System.Threading.Tasks.Task<ActionResult> Enviar_asiento_contableAsync()
        {
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

            var url = $"https://ec851079273a.ngrok.io/api/accountingEntry";
            var request = (HttpWebRequest) WebRequest.Create(url);
            var SeatsToSent = db.AccountSeats.Where(a => a.State == false).ToList();

            if (SeatsToSent.Count > 0)
            {
                var totalAmount = 0f;
                foreach (var seat in SeatsToSent) {

                    totalAmount += seat.SeatAmount;
                }
                /*
                {
                    "description": "test",
                    "idAuxiliarSystem": 2,
                    "movementType": "trna",
                    "entryDate": "2021-04-16T23:51:23.127Z",
                    "status": true,
                }*/
                //Envio de asiento.
                Root obj = new Root
                {
                    Descripcion = "Asiento contable, correspondiente al perdiodo: " + DateTime.UtcNow.Date.Month + "-" + DateTime.UtcNow.Date.Year,
                    IdCuentaAuxiliar = 3,
                    MovementType = "DB",
                    Asientos = new List<AccountSeat> 
                    { 
                        new AccountSeat 
                        {
                            Description = "Fanny",
                            CustomerId = 3,
                            AccountNumber = 13,
                            MType = "DB",
                            SeatDate = "" + DateTime.UtcNow.Date,
                            SeatAmount = Convert.ToInt32(totalAmount),
                            State = false 
                        } 
                    }
                };
                
                var data = new JavaScriptSerializer().Serialize(obj);

                //Enviar a ws externo


                string Baseurl = "https://ec851079273a.ngrok.io/";
                List<AccountSeat> Seats = new List<AccountSeat>();

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient 
                    var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync("api/accountingEntry", content);


                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var SeatResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //Seats = JsonConvert.DeserializeObject<List<AccountSeat>>(SeatResponse);

                    }
                }

                return null;


                /*const string url = "https://ec851079273a.ngrok.io/api/accountingEntry";
                HttpClient client = new HttpClient();
                client.BaseAddress = newUri("http://localhost:55587/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(newMediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();

                /*
               

                string json = data;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return "";
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                if (responseBody.Contains("Su número de asiento es #"))
                                {
                                    //processDAO.LogOnDB(desde, hasta);
                                }
                                return responseBody;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    return "ERR: " + ex.Status + " desc : " + ex.Message;
                }
            */
            }
            else
            {
                return null;//"No se han encontrado registros para el periodo evaluado.";

            }
        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {
            string Baseurl = "https://ec851079273a.ngrok.io/";
            List<AccountSeat> Seats = new List<AccountSeat>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/accountingEntry/auxiliars/3");


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SeatResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Seats = JsonConvert.DeserializeObject<List<AccountSeat>>(SeatResponse);

                }
            }
            return View(Seats);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

public class Root
{
    public string Descripcion { get; set; }
    public int IdCuentaAuxiliar { get; set; }
    public string MovementType { get; set; }
    public List<AccountSeat> Asientos { get; set; }
}