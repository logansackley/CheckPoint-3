using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class RentalController : Controller
    {
        public static List<Instrument> lstInstrument = new List<Instrument>()
        {
            new Instrument{InstrumentID = 1, InstrumentName = "Trumpet", NewPrice = 55, OldPrice = 25 },
            new Instrument{InstrumentID = 2,InstrumentName = "Trombone", NewPrice = 60, OldPrice = 35 },
            new Instrument{InstrumentID = 3,InstrumentName = "Tuba", NewPrice = 70, OldPrice = 50 },
            new Instrument{InstrumentID = 4,InstrumentName = "Flute", NewPrice = 40, OldPrice = 25 },
            new Instrument{InstrumentID = 5,InstrumentName = "Clarinet", NewPrice = 35, OldPrice = 27 },
            new Instrument{InstrumentID = 6,InstrumentName = "Saxophone", NewPrice = 42, OldPrice = 30 }
        };
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Instrument(int ID)
        {
            var oInstrument = lstInstrument.Find(x => x.InstrumentID == ID);
            return View(oInstrument);
        }
    }
}