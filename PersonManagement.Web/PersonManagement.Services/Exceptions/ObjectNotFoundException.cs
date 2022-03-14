using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string Code = "ObjectNotFound";

        public ObjectNotFoundException(string errorText) : base(errorText) { }
    }
}
