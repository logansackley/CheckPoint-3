using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class ClientsController : Controller
    {
        private BlowContext db = new BlowContext();
        public static int Holder; 
        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            


            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,firstname,lastname,address,city,state,zip,email,phone")] Client client)
        {
           
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "Update Instrument " +
                    "Set Instrument.ClientID = "  + client.ClientID + 
                    " Where Instrument.InstrumentID = " + Holder);

                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Summary", client);
            }
            
            return View(client);
        }

        public ActionResult Summary(Client client)
        {
            

            ViewBag.BangBang = int.Parse(InstrumentsController.SavePrice);
            ViewBag.Boom = InstrumentsController.SaveDESC;

            ViewBag.Finale += "<center>"+ "<p> Order Number: " + client.ClientID + "</p>" + "<br>";
            ViewBag.Finale += "<p> Order Description: " + InstrumentsController.SaveDESC + "</p>" + "<br>";
            ViewBag.Finale += "<p> Instrument Type: " + InstrumentsController.SaveType + "</p>" + "<br>";
            ViewBag.Finale += "<p> Monthly Rental Price: $" + InstrumentsController.SavePrice + ".00</p>" + "<br>" + "</center>";

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,firstname,lastname,address,city,state,zip,email,phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
