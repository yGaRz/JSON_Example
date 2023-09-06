using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON_JsonSerializer_vs_JSON_Newtonsoft
{ 
    internal class NewtonsoftExample
    {
        public static void NewtonsoftPerson()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Person p = new Person("Mike", "Big", 25);
            //Сериализуем объект в строку:
            Console.WriteLine("Person -> string:");
            string json = JsonConvert.SerializeObject(p);            
            Console.WriteLine(JToken.Parse(json).ToString());
            string test_js = string.Format("{{\"Name\":\"Mike\",\"Age\":25}}");
            //При десериализации строки можем получить структуру JObject к которой можем обращаться по ключам.
            var parcedJson = JsonConvert.DeserializeObject(test_js);
            Console.WriteLine(((JObject)parcedJson)["Name"]);
        }

        public static void NewtonsoftPersonList() 
        {
            Console.WriteLine("-----------------------------------------------------------");
            //Сериализуем list в Json
            List<Person> list = new List<Person>();
            list.Add(new Person("Mike", "Big", 25));
            list.Add(new Person("Antony", "Long", 22));
            list.Add(new Person("Misha", "Mini", 22));
            Console.WriteLine("List<person> -> string:");
            string json = JsonConvert.SerializeObject(list);
            Console.WriteLine(JToken.Parse(json).ToString());

            //Если мы знаем что json-строка это массив то парсим её в JArray
            JArray jArray= JArray.Parse(json);
            foreach (JObject p in jArray)
                Console.WriteLine(((JObject)p)["Name"]);

        }

        public  static void NewtonsoftDepartment()
        {
            Console.WriteLine("-----------------------------------------------------------");
            List<Person> list = new List<Person>();
            list.Add(new Person("Mike", "Big", 25));
            list.Add(new Person("Antony", "Long", 22));
            list.Add(new Person("Misha", "Mini", 22));
            //Сериализуем объект с list в Json
            Department department = new Department("Yandex", "Support");
            department.AddPerson(list);

            Console.WriteLine("Department - > string:");
            string jDep = JsonConvert.SerializeObject(department);
            Console.WriteLine(JToken.Parse(jDep).ToString());

            Console.WriteLine("String -> Department:");
            Department? dep = JsonConvert.DeserializeObject<Department>(jDep);
            Console.WriteLine($"{dep.Title} {dep.Description} {dep.Persons.Count}");

            Console.WriteLine("String -> JObject:");
            JObject? joDep = JsonConvert.DeserializeObject<JObject>(jDep);
            if (joDep != null)
            {
                Console.WriteLine($"{joDep["Title"]} {joDep["Description"]} {((JArray)joDep["Persons"]).Count}");
                foreach (JObject a in ((JArray)joDep["Persons"]))
                {
                    Console.WriteLine(a["Name"]);
                }
            }
        }

    }
}
