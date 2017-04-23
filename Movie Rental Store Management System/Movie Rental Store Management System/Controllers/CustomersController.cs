﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Rental_Store_Management_System.Models;
using Movie_Rental_Store_Management_System.ViewModel;

namespace Movie_Rental_Store_Management_System.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var customer = _Context.Customers.Include(c => c.MembershipType).ToList();
            if (!User.IsInRole("SuperAdmin")&&!User.IsInRole("Admin"))
                return View("Index",customer);
            else 
                return View("(Master1)Index",customer);
        }
        [Route("Customers/CreateCustomer")]
        [Authorize(Roles="SuperAdmin,Admin")]
        public ActionResult CreateCustomer()
        {
            var viewmodel = new ViewModel_CustomersMembershipType()
            { //Customer =new Customer(),
                MembershipTypes = _Context.MembershipTypes.ToList()
            };
            return View(viewmodel);

        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                //var customer = _Context.Customers.SingleOrDefault(c => c.Id == viewmodel.Customers.Id);

                var viewmodel1 = new ViewModel_CustomersMembershipType()
                    {Customer=customer,
                        MembershipTypes = _Context.MembershipTypes.ToList()
                    };
                return View("CreateCustomer", viewmodel1);

            }
            else
            {
                if (customer.Id!=null)
                {
                    var customers = _Context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                    customers.Name = customer.Name;
                    customers.DateOfBirth = customer.DateOfBirth;
                    customers.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customers.MembershipTypeId = customer.MembershipTypeId;

                }
                else
                {
                    _Context.Customers.Add(customer);
                    
                }
                _Context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        }
        public ActionResult Edit(int id)
        {
            var viewmodel = new ViewModel_CustomersMembershipType()
                {
                    Customer=_Context.Customers.SingleOrDefault(c=>c.Id==id),
                    MembershipTypes=_Context.MembershipTypes.ToList()
                   
                };

            return View("CreateCustomer",viewmodel);
        }
        public ActionResult Delete(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            var rentaldata = _Context.NewRentals.Where(c => c.Customer.Id == id);
            foreach(var rent in rentaldata)
            _Context.NewRentals.Remove(rent);
            _Context.SaveChanges();
            _Context.Customers.Remove(customer);
            
            _Context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        
        public JsonResult GetCustomersData(string query=null)
        {
            var customerquery = _Context.Customers.Include(c=>c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
                customerquery = customerquery.Where(c => c.Name.Contains(query));

            var customer = customerquery.ToList();

            return Json(customer, JsonRequestBehavior.AllowGet);
            //return customer;

        }

    }
}