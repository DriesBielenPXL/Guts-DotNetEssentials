using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    public class Person
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string name, string firstname, string gender, string address, string phone, DateTime birthDate)
        {
            Name = name;
            Firstname = firstname;
            Gender = gender;
            Address = address;
            Phone = phone;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{Firstname} {Name}";
        }
    }
}
