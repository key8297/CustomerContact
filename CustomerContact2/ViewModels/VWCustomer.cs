using CustomerContact2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerContact2.ViewModels
{
    public class VWCustomer
    {
        public bool IsNew { get; set; }
        public Customer Customer { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}