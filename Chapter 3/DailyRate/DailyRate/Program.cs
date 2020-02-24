using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRate
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();

            
            
        }

        void run()
        {
            double dailyRate = readDouble("Please enter your daily rate: ");

            int noOfDays = readInt("Please enter number of days: ");

            writeFee(calculateFee(dailyRate,noOfDays));

            Console.ReadLine();


        }

        private void writeFee(double v) => Console.WriteLine($"The consultancy fee was {v * 1.1} ");
       

        private double calculateFee(double dailyRate, int noOfDays) => dailyRate * noOfDays;
       

        private int readInt(string v)
        {
            Console.WriteLine(v);
            string line = Console.ReadLine();

            return int.Parse(line);
        }

        private double readDouble(string v)
        {
            Console.WriteLine(v);
            string line = Console.ReadLine();

            return double.Parse(line);
        }
    }
}
