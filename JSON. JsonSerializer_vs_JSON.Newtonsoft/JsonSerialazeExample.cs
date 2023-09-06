using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSON_JsonSerializer_vs_JSON_Newtonsoft
{
    internal class JsonSerialazeExample
    {
        public static string PersonToString(Person p)
        {
            return JsonSerializer.Serialize(p);
        }
        public static string ListPersonToString(List<Person> list)
        {
            return JsonSerializer.Serialize(list);
        }
        public static void JsonPerson()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Person p = new Person("Mike", "Big", 25);
            //Сериализуем объект в строку:
            Console.WriteLine("Person -> string:");
            Console.WriteLine(p.ToString());
            string js = p.ToString();
            Console.WriteLine("string -> Person:");
            Person? new_p = JsonSerializer.Deserialize<Person>(js);
            if (new_p != null)
            {
                new_p.Name = "Super Mike";
                Console.WriteLine($"{new_p.Name} {new_p.Surname} {new_p.Age}");
            }
            //Сериализация из неполной строки
            Console.WriteLine("string not full -> Person:");
            string test_js = string.Format("{{\"Name\":\"Mike\",\"Age\":25}}");
            new_p = JsonSerializer.Deserialize<Person>(test_js);
            if (new_p != null)
            {
                new_p.Name = "Super Mike";
                Console.WriteLine($"{new_p.Name} {new_p.Surname} {new_p.Age}");
            }
        }
        public static void JsonListOfPerson()
        {
            Console.WriteLine("-----------------------------------------------------------");
            //Сериализуем list в Json
            List<Person> list = new List<Person>();
            list.Add(new Person("Mike", "Big", 25));
            list.Add(new Person("Antony", "Long", 22));
            list.Add(new Person("Misha", "Mini", 22));
            Console.WriteLine("List<person> -> string:");
            string str = ListPersonToString(list);
            Console.WriteLine(str);
            //Пример входной строки с пустыми полями/пропусками свойств.
            str = string.Format("[{{\"Name\":\"\",\"Surname\":\"Big\",\"Age\":25}},{{\"Name\":\"Antony\",\"Age\":22}},{{\"Name\":\"Misha\",\"Surname\":\"Mini\"}}]");
            List<Person>? lst = JsonSerializer.Deserialize<List<Person>>(str);
            foreach (var a in lst)
            {
                Console.WriteLine(a.ToString());
            }
        }
        public static void JsonDepartment()
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
            string res = department.ToString();
            Console.WriteLine(res);

            Console.WriteLine("string -> Department");
            string str = string.Format("{{\"Title\":\"Yandex\",\"Description\":\"Support\"," +
                "\"Persons\":[{{\"Name\":\"Mike\",\"Surname\":\"Big\"}}," +
                                "{{\"Surname\":\"Long\",\"Age\":22}}," +
                                "{{\"Name\":\"Misha\",\"Age\":22}}]}}");
            //string str = string.Format("{{\"Title\":\"Yandex\",\"Description\":\"Support\",\"Persons\":[{{\"Name\":\"\",\"Surname\":\"Big\",\"Age\":25}},{{\"Name\":\"Antony\",\"Age\":22}},{{\"Name\":\"Misha\",\"Surname\":\"Mini\"}}]}}");
            Department? jDep = JsonSerializer.Deserialize<Department>(str);
            if (jDep != null)
                Console.WriteLine(jDep.ToString());
        }
    }
}
