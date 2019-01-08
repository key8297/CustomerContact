using CustomerContact2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerContact2.ViewModels
{
    public class VWCustomerLink:VWCustomer
    {
        public IEnumerable<Contact> AllContacts { get; set; }
    }
}