using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ENResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public Object result { get; set; }

        public ENResult(int codeParameter,string messageParameter)
        {
            code = codeParameter;
            message = messageParameter;
        }

        public ENResult(int codeParameter, string messageParameter, Object resultParameter)
        {
            code = codeParameter;
            message = messageParameter;
            result = resultParameter;
        }
    }
}
