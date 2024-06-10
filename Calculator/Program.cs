using System;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

public class Calculator
{
    public static void main(String[] args)
    {
        Console.WriteLine("Welcome to the Calculator!");
        bool continueYN = true;

        while(continueYN)
        {
            Console.Write("Write an expression to calculate: ");
            String input = Console.ReadLine();
            String ans = HandleInput(input);
            Console.WriteLine(ans);

            Console.WriteLine("Would you like to put in another expression? [y/n]");
            String YN = Console.ReadLine();

            if (YN.ToUpper().StartsWith('N'))
            {
                continueYN = false;
            }
        }

        Console.WriteLine("You have Exited the Calcualtor.");
    }

    public static String HandleInput(String input)
    {
        String[] Operators = { "+", "-", "*", "/", "%"};
        String oper = "";
        String arg1 = "";
        String arg2 = "";

        double num1 = double.NaN;
        double num2 = double.NaN;

        DateTime dateTime1;
        DateTime dateTime2;

        foreach (String o in Operators)
        {
            if(input.Contains(o)) {
                oper = o;
                int index = input.IndexOf(o);
                arg1 = input.Substring(0, index).Trim();
                arg2 = input.Substring(index + 1).Trim();
            }
        }

        if (oper == "")
        {
            Console.WriteLine("Missing an operator, please add one of +, -, *, /, %");
        }

        bool arg1IsNumber = double.TryParse(arg1, out num1);
        bool arg2IsNumber = double.TryParse(arg2, out num2);

        bool arg1IsDate = DateTime.TryParseExact(arg1, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out arg1);

        //Cases
        /* 1 - I get two doubles aka two numbers and I perform the operation
         * 2 - One arg is a date, in which case I can only do add/subract using AddDays
         * 3 - Both args are dates, in which case I find the difference between them
         * 4 - One or both inputs are invalid, in which case I return the error to the user
         * */


    }
}