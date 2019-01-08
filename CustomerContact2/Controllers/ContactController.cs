using CustomerContact2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerContact2.Controllers
{
    public class ContactController : Controller
    {
        //private CustomerContactEntities _db = new CustomerContactEntities();

        //public ActionResult Index()
        //{
        //    var contact = _db.Contacts.ToList();
        //    return View(contact);
        //}

        //public ActionResult Create()
        //{
        //    var contact = new VWContact() { IsNew = true, Contact = new Contact() };
        //    return View("Maint", contact);
        //}

        //public ActionResult Edit(Guid id)
        //{
        //    var contact = new VWContact() { IsNew = false };
        //    contact.Customer = _db.Contacts.FirstOrDefault(x => x.Id.Equals(id));
        //    contact.Contacts = _db.CustomerContactRelations.Where(x => x.Customer == id).Select(x => _db.Contacts.FirstOrDefault(y => y.Id == x.Contact)).ToList();
        //    return View("Maint", contact);
        //}

        //[HttpPost]
        //public ActionResult Save([Bind(Include = "Hid,Id,Name,Code,Address,Phone,WebSite,Created,CreatedBy,Modified,ModifiedBy")] Contact contact)
        //{
        //    bool isNew = contact.Hid == 0;
        //    if (isNew)
        //    {
        //        contact.Id = Guid.NewGuid();
        //        contact.Created = DateTime.Now;
        //        contact.Modified = DateTime.Now;

        //        int r = (new Random(123423).Next() + 1000000);
        //        contact.Code = "C" + r.ToString();
        //        _db.Contacts.Add(contact);
        //    }
        //    else
        //    {
        //        contact.Modified = DateTime.Now;
        //        _db.Entry(contact).State = EntityState.Modified;
        //    }

        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(Guid id)
        //{
        //    var ccr = _db.CustomerContactRelations;
        //    ccr.RemoveRange(ccr.Where(x => x.Customer == id));

        //    var contact = _db.Contacts.FirstOrDefault(x => x.Id == id);
        //    _db.Contacts.Remove(contact);

        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult LinkContact(Guid id, string lastUrl)
        //{
        //    var allContacts = _db.Contacts;
        //    var model = new VWContactLink();
        //    model.Contact = _db.Contacts.First(x => x.Id.Equals(id));

        //    var links = _db.CustomerContactRelations.Where(x => x.Customer.Equals(id)).ToList();

        //    if (links.Count > 0)
        //    {
        //        model.Contacts = _db.CustomerContactRelations.Where(x => x.Contact.Equals(id)).Select(x => allContacts.FirstOrDefault(y => y.Id == x.Contact)).ToList();
        //    }
        //    else
        //    {
        //        model.Contacts = new List<Contact>();
        //    }

        //    model.AllContacts = allContacts.ToList();
        //    ViewBag.lastUrl = lastUrl;
        //    return View(model);
        //}

    }
}