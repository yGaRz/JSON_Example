using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON_JsonSerializer_vs_JSON_Newtonsoft
{
    internal class Person
    {
        //Сылка на свойства JsonIgnore
        //https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json/ignore-properties?pivots=dotnet-7-0
        //Свойство не сериализуется если null
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Surname { get; set; }
        public int Age { get; set; }
        public Person(string name, string surname, int age) 
        { 
            Name= name;
            Surname = surname;
            if (age < 0)
                throw new ArgumentOutOfRangeException();
            Age = age;
        }
        public Person() { 
            Age = 0;

        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
