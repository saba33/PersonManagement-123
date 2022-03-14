using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Models.Requests
{
    public class PutPersonRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public bool IsBankCustomer { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public List<PersonBankAccountRequest> Accounts { get; set; }
    }
}
