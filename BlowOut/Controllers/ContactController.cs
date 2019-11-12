using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
       
        // GET: Contact
        public ViewResult Index()
        {
            string contact = "Please call Support at 801-555-1212. Thank you!";

            return View((Object)contact);
        }
    }
}