using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMHRD.API
{
    public class ServiceResponse<T>
    {
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public IList<T> List { get; set; }
        public T Obj { get; set; }
        public ServiceResponse()
        {
            List = new List<T>();
            Messages = new List<string>();
        }
    }
}