using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson_04._12._21
{
    class RationalNumbers
    {
        private  int numerator;
        private int denomerator;
        public RationalNumbers(int numerator, int denomerator)
        {
            if (denomerator == 0)
            {
                throw new Exception("Ошибка: невозможен 0 в знаменателе");
            }
            this.numerator = numerator;
            this.denomerator = denomerator;
        }
        public static RationalNumbers operator + (RationalNumbers num1, RationalNumbers num2)
        {
            return new RationalNumbers(num1.numerator * num2.denomerator + num2.numerator * num1.denomerator, num1.denomerator * num2.denomerator);
        } 
        public static RationalNumbers operator -(RationalNumbers num1, RationalNumbers num2)
        {
            return new RationalNumbers(num1.numerator * num2.denomerator - num2.numerator * num1.denomerator, num1.denomerator * num2.denomerator);
        }
        public static RationalNumbers operator ++(RationalNumbers num)
        {
            return new RationalNumbers(num.numerator + num.denomerator, num.denomerator);
        }
        public static RationalNumbers operator --(RationalNumbers num)
        {
            return new RationalNumbers(num.numerator - num.denomerator, num.denomerator);
        }
        public static bool operator ==(RationalNumbers num1, RationalNumbers num2)
        {
            return num1.numerator == num2.numerator && num1.denomerator == num2.denomerator;
        }
        public static bool operator !=(RationalNumbers num1, RationalNumbers num2)
        {
            return !(num1.numerator == num2.numerator && num1.denomerator == num2.denomerator);
        }
        public static bool operator <(RationalNumbers num1, RationalNumbers num2)
        {
            return num1.numerator * num2.denomerator < num2.numerator * num1.denomerator;
        }
        public static bool operator >(RationalNumbers num1, RationalNumbers num2)
        {
            return num1.numerator * num2.denomerator > num2.numerator * num1.denomerator;
        }
        public static bool operator <=(RationalNumbers num1, RationalNumbers num2)
        {
            return num1.numerator * num2.denomerator <= num2.numerator * num1.denomerator;
        }
        public static bool operator >=(RationalNumbers num1, RationalNumbers num2)
        {
            return num1.numerator * num2.denomerator >= num2.numerator * num1.denomerator;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if(obj is RationalNumbers)
            {
                result = Equals(obj as RationalNumbers);
            }
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.numerator + "/" + this.denomerator;
        }
    }
}
