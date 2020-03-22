using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFIrstTime
{
    class jsonParseAddress : jsonParseSample
    {
        public Address address { get; set; }

        public class Address
        {
            public string city { get; set; }
            public string street { get; set; }
            public string code { get; set; }
        }
    }
}
