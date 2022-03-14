using System;


namespace PersonManagement.Domain.POCO
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Identifier{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}
