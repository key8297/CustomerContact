using CustomerContact2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace CustomerContact2.Controllers
{
    public class CustomerApiController : ApiController
    {
        private CustomerContactEntities _db = new CustomerContactEntities();

        [HttpGet]
        public IHttpActionResult ImportDummy()
        {
            var stringData = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~\data\company.json"));
            var customers = JsonConvert.DeserializeObject<List<Customer>>(stringData);

            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE Customers");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE Contacts");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE CustomerContactRelation");

            var rand = new Random();            
            foreach (var item in customers)
            {
                int r = (rand.Next(2315, 8999999) + 1000000);
                item.Id = Guid.NewGuid();
                item.Created = DateTime.Now;
                item.Modified = DateTime.Now;
                item.Code = "C" + r.ToString();
                if (item.Phone.Length > 20)
                {
                    item.Phone = item.Phone.Substring(0, 20).Trim();
                }
                _db.Customers.Add(item);
            }

            stringData = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~\data\contact.json"));
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(stringData);

            foreach (var item in contacts)
            {
                item.Id = Guid.NewGuid();
                item.Created = DateTime.Now;
                item.Modified = DateTime.Now;
                if (item.Phone.Length > 20)
                {
                    item.Phone = item.Phone.Substring(0, 20).Trim();
                }
                _db.Contacts.Add(item);
            }

            _db.SaveChanges();

            return Json("Completed");
        }
        
        [HttpPost]
        public HttpResponseMessage LinkContact([FromBody]LinkInfo linkInfo)
        {

            var relation = new CustomerContactRelation();
            relation.Contact = new Guid(linkInfo.contact);
            relation.Customer = new Guid(linkInfo.customer);
            relation.Created = DateTime.Now;

            _db.CustomerContactRelations.Add(relation);           

            _db.SaveChanges();

            var resp = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonConvert.SerializeObject(linkInfo), Encoding.UTF8, "application/json") };
            return resp;
        }

        [HttpPost]
        public HttpResponseMessage UnLinkContact([FromBody]LinkInfo linkInfo)
        {
            var relation = _db.CustomerContactRelations.FirstOrDefault(x => x.Customer == new Guid(linkInfo.customer) && x.Contact == new Guid(linkInfo.contact));

            if(relation != null)
            {
                _db.CustomerContactRelations.Remove(relation);
            }

            _db.SaveChanges();

            var resp = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonConvert.SerializeObject(linkInfo), Encoding.UTF8, "application/json") };
            return resp;
        }
    }
}