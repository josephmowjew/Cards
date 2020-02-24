#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

       public void Display()
        {
            Console.WriteLine($" point X is {this.x} and point Y is {this.y}");
        }
    }
}
