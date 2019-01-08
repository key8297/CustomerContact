using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerContact2.Models
{
    public class TestCheckBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }

    public class TestCheckBoxes
    {
        public List<TestCheckBox> data { get; set; }
    }
}