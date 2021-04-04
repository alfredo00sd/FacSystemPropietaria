﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FacSystemPropietaria.Models;

namespace FacSystemPropietaria.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bills
        public ActionResult Index()
        {
            return View(db.Bills.ToList());
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            var Products = db.Items.ToList();
            var Customers = db.Customers.ToList();

            var ViewModel = new NewItemsViewModel 
            {
                Items = Products,
                Customers = Customers,
            };

            return View(ViewModel);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Customer_Id,Fac_date,Comment,Total,ITEBIS")] Bill bill, BillDetails billDetails)
        {
            var DetailList = new List<BillDetails>();

            BillDetailVM vm = new BillDetailVM();
            vm.ItemsIds.Add(billDetails.Price);
            vm.Quantity.Add(billDetails.Quantity);

            var ItemsAndQuantities = vm.ItemsIds.Zip(vm.Quantity, (i, q) => new { Item = i, Quantity = q});

            foreach (var item in ItemsAndQuantities) 
            {
              DetailList.Add (
                new BillDetails 
                {
                    ItemId = Int32.Parse(item.Item),
                    Quantity =  item.Quantity
                });   
            }

            
            DateTime dateTime = DateTime.UtcNow.Date;
            bill.Fac_date = dateTime.ToString("dd/MM/yyyy");
            bill.State = true;
            bill.ITEBIS = "18%";
            bill.Total = "5,000.00";
            
            bill.ItemDetailsId = "Carajo";

            bill.Employee_Id = User.Identity.Name;
            //bill.Items = new System.Collections.Generic.List<Items> { new Items { Description = "Shampoo", Price = 500, Quantity = 2 } };
            
           if (ModelState.IsValid)
           {
                db.Bills.Add(bill);
                db.SaveChanges();

                return RedirectToAction("Index");
           }
            return null;
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Customer_Id,Fac_date,Comment,Total,ITEBIS")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
