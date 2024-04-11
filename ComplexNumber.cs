using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace prackt18
{
    class ComplexNumber
    {
        private double a;
        private double b;
        private double c;
        private double d;

        public ComplexNumber(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        static public string Add(double a, double b, double c, double d)
        {
            if (a+c==0) return $"{b + d}i";
            else if (b+d==0) return $"{a + c}";
            else if (b+d<0) return $"{a + c}{b + d}i";
            else return $"{a + c}+{b + d}i";
        }

        static public string Subtract(double a, double b, double c, double d)
        {
            if (a-c==0) return $"{b - d}i";
            else if (b-d==0) return $"{a - c}";
            else if (b-d<0) return $"{a - c}{b - d}i";
            else return $"{a - c}+{b - d}i";
        }

        static public string Multiply(double a, double b, double c, double d)
        {
            if (a * c - b * d==0) return $"{a * d + b * c}i";
            else if (a * d + b * c==0) return $"{a * c - b * d}";
            else if (a * d + b * c < 0) return $"{a * c - b * d}{a * d + b * c}i";
            else return $"{a * c - b * d} + {a * d + b * c}i";
        }
    }
}
