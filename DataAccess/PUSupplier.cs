//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PUSupplier
    {
        public int idSupplier { get; set; }
        public string name { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string contactPerson { get; set; }
        public bool active { get; set; }
        public string userCreated { get; set; }
        public System.DateTime dateCreated { get; set; }
        public string userUpdated { get; set; }
        public Nullable<System.DateTime> dateUpdated { get; set; }
    }
}