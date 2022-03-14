using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Services.Models.User
{
    public class UserServiceModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
