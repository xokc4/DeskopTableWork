using System;
using System.Collections.Generic;

#nullable disable

namespace DeskopTableWork
{
    public partial class Person
    {
        public Person(int id, string surname, string name, string lastname, string phone, string adress, string description)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Adress = adress;
            Description = description;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
    }
}
