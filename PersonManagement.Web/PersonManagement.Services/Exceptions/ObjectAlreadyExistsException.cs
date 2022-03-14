using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Exceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public string Code = "ObjectAlreadyExists";

        public ObjectAlreadyExistsException(string errorText) : base(errorText) { }
    }
}
