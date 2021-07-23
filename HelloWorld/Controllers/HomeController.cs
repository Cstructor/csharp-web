using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    [Logging]
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

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

            var myProduct = productRepository.Products.First();

            return View(myProduct);
        }

        public ActionResult Products()
        {
            var products = productRepository.Products;

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