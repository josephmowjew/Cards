using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<String, int>() {
                ["Gambiza"] = 25,
                ["Mary"] =22
            };


            foreach (KeyValuePair<string, int> person in people)
            {
                Console.WriteLine(person.Value.ToString());
            }


            Console.ReadLine();
                
        }
    }
}
