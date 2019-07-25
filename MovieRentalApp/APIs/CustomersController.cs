using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp.APIs
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get /api/customers
        //[HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
           return _context.Customers.ToList();
        }

        //Get /api/customers/id
        [HttpGet]
        public Customer FindCustomerById(int? id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
                _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut]
        public void UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.CustomerName = customer.CustomerName;
            customerInDb.Dob = customer.Dob;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cust = _context.Customers.Find(id);
            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(cust);
            _context.SaveChanges();

        }
    }
}
