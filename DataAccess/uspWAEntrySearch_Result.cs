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
    
    public partial class uspWAEntrySearch_Result
    {
        public int idEntry { get; set; }
        public Nullable<int> idStore { get; set; }
        public Nullable<int> idSupplier { get; set; }
        public string entryType { get; set; }
        public System.DateTime date { get; set; }
        public bool active { get; set; }
        public string userCreated { get; set; }
        public System.DateTime dateCreated { get; set; }
        public string userUpdated { get; set; }
        public Nullable<System.DateTime> dateUpdated { get; set; }
        public string store { get; set; }
        public string supplier { get; set; }
        public string dateYMD { get; set; }
    }
}
