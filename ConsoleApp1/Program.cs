using ConsoleApp1;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        double number1 = double.NaN;
        double number2 = double.NaN;
        double number3 = double.NaN;

        GetNumber("first", out number1);
        GetNumber("second", out number2);

        MathFunctions mathfunctions;

        Console.WriteLine("Do you want to add another number? [y/n]");
        String ans = Console.ReadLine();
        if(ans.Equals("y"))
        {
            GetNumber("third", out number3);
            mathfunctions = new MathFunctions(number1, number2, number3);
        }
        else
        {
            Console.WriteLine("ok, two numbers it is then...");
            mathfunctions = new MathFunctions(number1, number2);
        }

        Console.WriteLine(mathfunctions.DoMath(MathFunctionTypes.Add));
        Console.WriteLine(mathfunctions.DoMath(MathFunctionTypes.Multiply));
        Console.WriteLine(mathfunctions.DoMath(MathFunctionTypes.Difference));
        try
        {
            Console.WriteLine(mathfunctions.DoMath(MathFunctionTypes.Divide));
        }
        catch (DivideByZeroException) 
        {
            Console.WriteLine("You cannot divide by zero silly");
        }


        Console.WriteLine(number1 + " is an " + evenOdd(number1) + " number");
        
        if(number1 > 0)
        {
            Console.WriteLine(number1);
        } else
        {
            Console.WriteLine(number1 * -1);
        }

    }
    // Static Method for getting the numbers and assigning them.
    /* String order is a string for what number order the number is
     i.e. "first" or "second"
     */
    public static void GetNumber(String order, out double number)
    {
        var numberParsed = false;
        number = double.NaN;

        while (!numberParsed)
        {
            Console.WriteLine("Enter the " + order + " number: ");
            numberParsed = double.TryParse(Console.ReadLine(), out number);
            if (!numberParsed)
            {
                Console.WriteLine("You gave the wrong input! Try Again!");
            }
        }
    }

    public static String evenOdd(double num1)
    {
        return num1 % 2 == 0 ? $"even" : "odd";

    }
}
