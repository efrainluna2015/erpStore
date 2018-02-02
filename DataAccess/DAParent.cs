using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAParent
    {
        public ObjectParameter PReturnCode = new ObjectParameter("returnCode", 0);
        public ObjectParameter PReturnMessage = new ObjectParameter("returnMessage", "");
        public string PUser = "";

        public DAParent (string userParameter)
        {
            PUser = userParameter;
        }

        public ENResult PUnexpectedError(Exception ex)
        {
            return new ENResult(2, ex.Message.ToString());
        }

    }
}
