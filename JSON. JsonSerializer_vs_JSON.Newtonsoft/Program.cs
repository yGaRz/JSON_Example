using System.Collections.Generic;
using System.Text.Json;


namespace JSON_JsonSerializer_vs_JSON_Newtonsoft
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            NewtonsoftExample.NewtonsoftPerson();
            NewtonsoftExample.NewtonsoftPersonList();
            NewtonsoftExample.NewtonsoftDepartment();

            //JsonSerialazeExample.JsonPerson();
            //JsonSerialazeExample.JsonListOfPerson();
            //JsonSerialazeExample.JsonDepartment();
        }
    }

}