using System;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

public class Calculator
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Welcome to the Calculator!");
        bool continueYN = true;

        while(continueYN)
        {
            Console.WriteLine("Write an expression to calculate in the format [arg1] [operator] [arg2], for DateTimes, use the format (MM/dd/yyyy)");
            Console.Write("Your expression: ");
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

        String ans = "";

        double num1 = double.NaN;
        double num2 = double.NaN;

        DateTime dateTime1 = DateTime.Now;
        DateTime dateTime2 = DateTime.Now;


        //Doesn't handle case of negative numbers input i.e. -50 - -30 = -20
        foreach (String o in Operators)
        {
            if(input.Contains(o)) {
                oper = o;
                int index = input.IndexOf(o);
                arg1 = input.Substring(0, index).Trim();
                arg2 = input.Substring(index + 1).Trim();
                break;
            }
        }

        if (oper == "")
        {
            return "Missing an operator, please add one of +, -, *, /, %";
        }

        bool arg1IsNumber = double.TryParse(arg1, out num1);
        bool arg2IsNumber = double.TryParse(arg2, out num2);

        bool arg1IsDate = DateTime.TryParseExact(arg1, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime1);
        bool arg2IsDate = DateTime.TryParseExact(arg2, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime2);

        //Cases
        /* 1 - I get two doubles aka two numbers and I perform the operation
         * 2 - One arg is a date, in which case I can only do add/subract using AddDays
         * 3 - Both args are dates, in which case I find the difference between them
         * 4 - One or both inputs are invalid, in which case I return the error to the user
         * */


        if (arg1IsNumber && arg2IsNumber)
        {
            try
            {
                ans = "" + HandleNums(num1, num2, oper);
            } catch (Exception ex)
            {
                //Allows the handler to return the divide by zero exception, but calculator continues
                ans += ex.ToString();
            }
            
        }
        else if (arg1IsDate && arg2IsNumber)
        {
            dateTime1 = dateTime1.AddDays(num2);
            ans = dateTime1.ToShortDateString();
        }
        else if(arg1IsNumber && arg2IsDate)
        {
            dateTime2 = dateTime2.AddDays(num1);
            ans = dateTime2.ToShortDateString();
        }
        else if(arg1IsDate && arg2IsDate)
        {
            TimeSpan difference = dateTime2 - dateTime1;
            ans = $"Difference: {difference.TotalDays} days, {difference.TotalHours} hours, {difference.TotalMinutes} minutes";
        }
        else
        {
            if(!arg1IsNumber && !arg1IsDate)
            {
                ans = "Your first argument was invalid, please enter a number or a date without any internal operators for the first argument.";
            }
            else
            {
                ans = "Your second argument was invalid, please enter a number or a date without any internal operators for the second argument.";
            }
        }

        return ans;

    }

    public static double HandleNums(double num1, double num2, String oper)
    {
        switch (oper)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                return num2 != 0? num1 / num2 : throw new DivideByZeroException();
            case "%":
                return num2 != 0 ? num1 % num2 : throw new DivideByZeroException();
        }
        return num1;
    }
}