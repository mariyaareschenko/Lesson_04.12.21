using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_04._12._21
{
    class ComplexNumbers
    {
        private double real;
        private double imagine;
        public ComplexNumbers(double real, double imagine)
        {
            this.real = real;
            this.imagine = imagine;
        }
        public static ComplexNumbers operator +(ComplexNumbers num1, ComplexNumbers num2)
        {
            return new ComplexNumbers(num1.real + num2.real, num1.imagine + num2.imagine);
        }
        public static ComplexNumbers operator -(ComplexNumbers num1, ComplexNumbers num2)
        {
            return new ComplexNumbers(num1.real - num2.real, num1.imagine - num2.imagine);
        }
        public static ComplexNumbers operator *(ComplexNumbers num1, ComplexNumbers num2)
        {
            return new ComplexNumbers(num1.real * num2.real - num1.imagine * num2.imagine, num1.real * num2.real + num1.imagine * num2.imagine);
        }
        public static bool operator==(ComplexNumbers num1, ComplexNumbers num2)
        {
            return num1.real == num2.real && num1.imagine == num2.imagine;
        }
        public static bool operator !=(ComplexNumbers num1, ComplexNumbers num2)
        {
            return !(num1.real == num2.real && num1.imagine == num2.imagine);
        }
        public override string ToString()
        {
            if(this.real == 0)
            {
                return $"{this.imagine}";
            }
            else if(this.imagine == 0)
            {
                return $"{this.real}";
            }
            else if (this.imagine < 0)
            {
                return $"{this.real}{this.imagine}i";
            }
            else
            {
                return $"{this.real} + {this.imagine}i";
            }
        }
    }
}
