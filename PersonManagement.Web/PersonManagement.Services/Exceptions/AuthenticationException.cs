using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Exceptions
{
    public class AuthenticationException1 : Exception
    {
        public string Code = "UnAuthUser";

        public AuthenticationException1(string errorText) : base(errorText) { }
    }
}
