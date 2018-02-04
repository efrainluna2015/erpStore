using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class ENUser
    {
        public string userName { get; set; }
        public int idProfile { get; set; }
        public int idStore { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string profileName { get; set; }
        public string storeName { get; set; }
        public List<ENUserAction> actions { get; set; }
    }
    public class ENUserAction
    {
        public string code { get; set; }
        public string name { get; set; }

        public ENUserAction (string codeParameter, string nameParameter)
        {
            code = codeParameter;
            name = nameParameter;
        }
    }
}