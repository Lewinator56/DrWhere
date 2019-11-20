using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrWhere
{
    // holds details about each service to be written to the dataGrid, used to AUTOGENERATE the columns
    class ServicesData
    {
        public string Postcode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public bool Private { get; set; }

        public float Distance { get; set; }
    }
}
