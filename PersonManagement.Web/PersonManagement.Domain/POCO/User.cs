using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Domain.POCO
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstNam { get; set; }
        public string LastName { get; set; }
    }
}
