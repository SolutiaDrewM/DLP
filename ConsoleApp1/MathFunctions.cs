using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MathFunctions
    {
        double num1, num2, num3;

        public MathFunctions(double number1, double number2, double number3 = double.NaN)
        {
            num1 = number1;
            num2 = number2;
            num3 = number3;

        }

        public double Number1 { get { return num1; } }
        public double Number2 { get { return num2; } }
        public double Number3 { get { return num3; } }

        public double DoMath(MathFunctionTypes functionType)
        {
            switch (functionType)
            {
                case MathFunctionTypes.Add: 
                    return Add(num1, num2, num3);
                case MathFunctionTypes.Difference:
                    return Difference(num1, num2, num3);
                case MathFunctionTypes.Multiply: 
                    return Multiply(num1, num2, num3);
                case MathFunctionTypes.Divide:
                    return Divide(num1, num2, num3);
                default: throw new NotImplementedException($"This enum value {functionType} has not been implemented");
            }

        }

        private double Add(double num1, double num2, double num3 = double.NaN)
        {
            if (num3 == double.NaN)
            {
                return num1 + num2;
            }
            return num1 + num2 + num3;
        }

        private double Multiply(double num1, double num2, double num3 = double.NaN)
        {
            if (num3 == double.NaN)
            {
                return num1 * num2;
            }
            return num1 * num2 * num3;
        }

        private double Difference(double num1, double num2, double num3 = double.NaN)
        {
            if (num3 == double.NaN)
            {
                return Math.Abs(num1 - num2);
            } else
            {
                throw new NotImplementedException("This function is not supported for 3 inputs");
            }
            
        }

        private double Divide(double num1, double num2, double num3 = double.NaN)
        {
            if (num3 == double.NaN)
            {
                return num2 != 0 ? num1 / num2 : throw new DivideByZeroException();
            }
            else
            {
                throw new NotImplementedException("This function is not supported for 3 inputs");
            }
        }

        public override String ToString()
        {
            return String.Concat($"Number 1 is: {Number1}, Number 2 is: {Number2}, Number 3 is: {Number3} ");
        }

    }
}
