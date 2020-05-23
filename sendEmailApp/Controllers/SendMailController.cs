using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sendEmailApp.Models;
using System.Net.Mail;

namespace sendEmailApp.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;

            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("noreply1.2.3replyno@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.sendgrid.net");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("apikey",
                "");
            smtp.Send(mm);

            ViewBag.Message = "The mail has been sent to " + mm.To + " Sucessfully!";

            return View();
        }


    }
}
