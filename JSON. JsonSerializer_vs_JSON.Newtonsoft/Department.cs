using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace JSON_JsonSerializer_vs_JSON_Newtonsoft
{
    internal class Department
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Person> Persons { get; set; }
        public Department(string title, string descripton) 
        { 
            Persons = new List<Person>();
            Title = title;
            Description = descripton;
        }
        public  Department() {
            Persons = new List<Person>();
            Title= string.Empty;
            Description= string.Empty;
        }
        public void AddPerson(Person p)
        {
            if (p == null)
                throw new NullReferenceException();
            Persons.Add(p);
        }
        public void AddPerson(List<Person> list)
        {
            if (list == null)
                throw new NullReferenceException();
            Persons.AddRange(list);
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
