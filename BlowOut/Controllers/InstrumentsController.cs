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
    public class InstrumentsController : Controller
    {
        private BlowContext db = new BlowContext();
        public static int SaveID;
        public static string SaveDESC;
        public static string SaveType;
        public static string SavePrice;
        public static int SaveClient;

        // GET: Instruments
        [HttpGet]
        public ActionResult Index()
        {

            return View(db.Instruments.ToList());
        }

        // GET: Instruments/Details/5
      
        public ActionResult Details(string Description)
        {

            if (Description == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Instrument> FindME =
             db.Database.SqlQuery<Instrument>(
             "Select InstrumentID, Description, Type, " +
             "Price, ClientID " +
             "FROM Instrument " +
             "WHERE Description =" + "'" + Description + "'");


            if (FindME == null)
            {
                return HttpNotFound();
            }
            return View(FindME);
        }
 
        public ActionResult SaveInstrument(int myID, string myDESC, string myType, string myPrice)
        {
            SaveID = myID;
            SaveDESC = myDESC;
            SavePrice = myPrice;
            SaveType = myType;

            return RedirectToAction("Create", "Clients");

        }

        // GET: Instruments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstrumentID,Description,Type,Price,ClientID")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                db.Instruments.Add(instrument);
                db.SaveChanges();
                return View("Index");
            }

            return View(instrument);
        }

      

        // GET: Instruments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstrumentID,Description,Type,Price,ClientID")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrument instrument = db.Instruments.Find(id);
            db.Instruments.Remove(instrument);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
