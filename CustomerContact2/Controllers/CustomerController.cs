using CustomerContact2.Models;
using CustomerContact2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerContact2.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerContactEntities _db = new CustomerContactEntities();

        public ActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var customer = new VWCustomer() { IsNew = true, Customer = new Customer() };
            return View("Maint", customer);
        }

        public ActionResult Edit(Guid id)
        {
            var customer = new VWCustomer() { IsNew = false };
            customer.Customer = _db.Customers.FirstOrDefault(x => x.Id.Equals(id));
            customer.Contacts = _db.CustomerContactRelations.Where(x => x.Customer == id).Select(x => _db.Contacts.FirstOrDefault(y => y.Id == x.Contact)).ToList();
            return View("Maint", customer);
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "Hid,Id,Name,Code,Address,Phone,WebSite,Created,CreatedBy,Modified,ModifiedBy")] Customer customer)
        {
            bool isNew = customer.Hid == 0;
            if (isNew)
            {
                customer.Id = Guid.NewGuid();
                customer.Created = DateTime.Now;
                customer.Modified = DateTime.Now;

                int r = (new Random(123423).Next() + 1000000);
                customer.Code = "C" + r.ToString();
                _db.Customers.Add(customer);
            }
            else
            {
                customer.Modified = DateTime.Now;
                _db.Entry(customer).State = EntityState.Modified;
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var ccr = _db.CustomerContactRelations;
            ccr.RemoveRange(ccr.Where(x => x.Customer == id));

            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            _db.Customers.Remove(customer);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LinkContact(Guid id, string lastUrl)
        {
            var allContacts = _db.Contacts;
            var model = new VWCustomerLink();
            model.Customer = _db.Customers.First(x => x.Id.Equals(id));

            var links = _db.CustomerContactRelations.Where(x => x.Customer.Equals(id)).ToList();

            if (links.Count > 0)
            {
                model.Contacts = _db.CustomerContactRelations.Where(x => x.Customer.Equals(id)).Select(x => allContacts.FirstOrDefault(y => y.Id == x.Contact)).ToList();
            }
            else
            {
                model.Contacts = new List<Contact>();
            }
            
            model.AllContacts = allContacts.ToList();
            ViewBag.lastUrl = lastUrl;
            return View(model);
        }

    }
}
