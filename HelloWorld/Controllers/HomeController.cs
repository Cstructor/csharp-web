using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            var guestResponse = new Models.GuestResponse
            {
                SelectItems = new[]
               {
                new SelectListItem { Text="Yes, I'll be there", Value=bool.TrueString},
                new SelectListItem{Text="No, I can't come", Value=bool.FalseString},
                }
            };

            return View(guestResponse);
        }

        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                guestResponse.SelectItems = new[]
                      {
                        new SelectListItem { Text="Yes, I'll be there", Value=bool.TrueString},
                        new SelectListItem{Text="No, I can't come", Value=bool.FalseString},
                        };

                return View(guestResponse);
            }
        }
    }
}