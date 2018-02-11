using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class ENProductProperty
    {
        public int idProperty { get; set; }
        public int idProduct { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public bool required { get; set; }
    }
}