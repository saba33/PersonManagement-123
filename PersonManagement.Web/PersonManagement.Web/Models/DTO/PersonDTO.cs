using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Models.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string CityName { get; set; }
    }
}
