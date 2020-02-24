using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
		//declaring dynamic properties for the class
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public Complex(int real, int imaginary)
        {
			//initialising the properties with input from the user
            this.Real = real;
            this.Imaginary = imaginary;
        }

		//Declaring a constructor that expects a single Real number
        public Complex(int real)
        {
			
            this.Real = real;
            this.Imaginary = 0;
        }

        public static implicit operator Complex(int from)
        {
            return new Complex(from);
        }

        public static explicit operator int(Complex from)
        {
            return from.Real;
        }

        public override string ToString()
        {
            return $"({this.Real} + {this.Imaginary}i)";
        }

		//defining what the plus operator does one the complex numbers
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);
        }

		//defining what the minus operator does one the complex numbers
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);
        }

		//defining what the multiplication operator does one the complex number
        public static Complex operator *(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary,
                lhs.Imaginary * rhs.Real + lhs.Real * rhs.Imaginary);
        }
	
	//defining what the division operator does one the complex number
        public static Complex operator /(Complex lhs, Complex rhs)
        {
            int realElement = (lhs.Real * rhs.Real + lhs.Imaginary * rhs.Imaginary) /
                (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary);

            int imaginaryElement = (lhs.Imaginary * rhs.Real - lhs.Real * rhs.Imaginary) /
                (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary);

            return new Complex(realElement, imaginaryElement);
        }

		//defining what the equal operator does one the complex number
        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return lhs.Equals(rhs);
        }

		//defining what the NOT operator does one the complex number
        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return !(lhs.Equals(rhs));
        }
	
		//defining these numbers will be compared 
        public override bool Equals(object obj)
        {
            if(obj is Complex)
            {
                Complex compare = (Complex)obj;
                return (this.Real == compare.Real) &&
                    (this.Imaginary == compare.Imaginary);
            }
            else
            {
                return false;
            }
        }

		//defining how the hashcode will be calculated when the complex numbers are used with collections
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
