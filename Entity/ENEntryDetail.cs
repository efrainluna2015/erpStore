using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ENEntryDetail
    {
        public int idEntry { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
        public decimal purchasePrice { get; set; }
        public DateTime dueDate { get; set; }
        public List<ENEntryDetailProperty> listDetailProperty { get; set; }
    }
}
