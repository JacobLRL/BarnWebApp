using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BarnWebApp.Models;
using Microsoft.AspNet.Identity;

namespace BarnWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        // POST: /Contact
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityMessage identityMessage = new IdentityMessage();
                identityMessage.Body = model.Message;
                identityMessage.Destination = ConfigurationManager.AppSettings["Email"].ToString();
                identityMessage.Subject = model.Subject + " From: " + model.Email;
                EmailService emailService = new EmailService();
                await emailService.SendAsync(identityMessage);
                TempData["Success"] = "Email Sent Successfully";
                return RedirectToAction("Contact");
            }
            return View(model);
        }
    }
}