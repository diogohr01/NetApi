using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model
{
    public class Person
    {
        public long id { get; set; }
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string address  { get; set; }

        public string gender { get; set; }
    }
}