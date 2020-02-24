using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {

        static void doWork()
        {
            //create a location  using two points
            Point location = new Point(20, 10);

            location.Display();

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
  
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
