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
            //int x = 1;  // add me
            //x = x / (x - 1); // add me

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Product()
        {
            ViewBag.MuyTitle = "hello";

            var myProduct = new Models.Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "water-sports",
                Price = 200m,
            };

            return View(myProduct);
        }

        public ActionResult Products()
        {
            var products = new Models.Product[]
            {
                new Models.Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount = 0},
                new Models.Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount = 1},
                new Models.Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount= 2 },
                new Models.Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount = 3},
            };

            //foreach (var item in products)
            //{
            //    try
            //    {
            //        if (item != null)
            //        {
            //            item.Price =  2/ item.Price;
            //        }
            //        else
            //        {
            //            // email developer
            //        }
            //    }
            //    catch (DivideByZeroException ex)
            //    {
            //        // log productId
            //        //item.Hide = true;
            //        //throw;
            //    }
            //    catch (FieldAccessException ex)
            //    {
            //        // log
            //        throw;
            //    }
            //    catch (Exception ex)
            //    {
            //        // log
            //        // email
            //    }
            //}

            return View(products);
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