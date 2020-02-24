using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        void run()
        {
            Console.WriteLine("Please write a positive integer");

            string inputValue = Console.ReadLine();
            long factorialValue = CalculateFactorial(inputValue);
            Console.WriteLine($"factory({inputValue}) is {factorialValue} ");

            Console.ReadLine();
        }

        private long CalculateFactorial(string input)
        {
            //convert input value to integer

            int inputValue = int.Parse(input);

            long factorial(int dataValue)
            {
                if(dataValue == 1)
                {
                    return 1;
                }
                else
                {
                    return dataValue * factorial(dataValue - 1);
                }
    
            }

            long factorialValue = factorial(inputValue);
            return factorialValue;
        }
    }
}
