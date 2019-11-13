using BlowOut.Models;
using EASendMail;
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
        public ActionResult Index()
        {
            string contact = "Please call Support at <b><u>801-555-1212.</u></b> Thank you!";
            ViewBag.Contact = contact;
            return View();
        }

        public ActionResult Email(String name, String email)
        {
            
                string ThankYou = "Thank you " + name + ". We will be sending you an email at " + email;
                ViewBag.Thanks = ThankYou;

                    try
                    {
                        SmtpMail oMail = new SmtpMail("TryIt");

                        // Your gmail email address
                        oMail.From = "403projectictus@gmail.com";

                        // Set recipient email address
                        oMail.To = email;

                        // Set email subject
                        oMail.Subject = "test email from gmail account";

                        // Set email body
                        oMail.TextBody = "Gimme my 5 points bitch.";

                        // Gmail SMTP server address
                        SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                        // Gmail user authentication
                        // For example: your email is "gmailid@gmail.com", then the user should be the same
                        oServer.User = "403projectictus@gmail.com";
                        oServer.Password = "Givemeextracredit";

                        // If you want to use direct SSL 465 port,
                        // please add this line, otherwise TLS will be used.
                        // oServer.Port = 465;

                        // set 587 TLS port;
                        oServer.Port = 587;

                        // detect SSL/TLS automatically
                        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                        Console.WriteLine("start to send email over SSL ...");

                        SmtpClient oSmtp = new SmtpClient();
                        oSmtp.SendMail(oServer, oMail);

                        Console.WriteLine("email was sent successfully!");
                    }
                    catch (Exception ep)
                    {
                        Console.WriteLine("failed to send email with the following error:");
                        Console.WriteLine(ep.Message);
                    }
                return View("ThankYou");
            }
        }
}