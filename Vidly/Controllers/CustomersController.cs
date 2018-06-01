using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customerList = new List<Customer>
        {
            new Customer { Id = 1, Name = "Renato Nappo" },
            new Customer { Id = 2, Name = "Gareth Meech" },
            new Customer { Id = 3, Name = "Liam Wright" },
            new Customer { Id = 4, Name = "Allan Wheatley" },
            new Customer { Id = 5, Name = "Daniel Thompson" },
            new Customer { Id = 6, Name = "Darren Baldwin" }
        };



        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            CustomersViewModel customers = new CustomersViewModel { Customers = customerList };
            return View(customers);
        }


        [Route("customers/CustomerDetails/{id}")]
        public ActionResult CustomerDetails(int? id)
        {
            if(!id.HasValue)
            {
                return new RedirectResult("/customers");
            }
            else
            {
                List<Customer> FoundCustomers = customerList.Where(c => c.Id == id).ToList();
                if(FoundCustomers.Count > 0)
                {
                    return View((Customer)FoundCustomers[0]);
                }
                else
                {
                    return new RedirectResult("/customers");
                }
                
            }
        }
    }
}