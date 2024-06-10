using System;
using System.Globalization;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        //DateTime stuff on top
        DateTime now = DateTime.Now;
        Console.WriteLine("Current Date (Short): " + now.ToShortDateString());
        Console.WriteLine("Current Date (Long): " + now.ToLongDateString());

        // Use UTC for current date

        DateTime utcNow = DateTime.UtcNow;
        Console.WriteLine("Current Date (UTC): " + utcNow.ToString("yyyy-MM-dd HH:mm:ss"));

        // custom formats for it

        Console.WriteLine("Custom Format 1: " + now.ToString("dd-MM-yyyy"));
        Console.WriteLine("Custom Format 2: " + now.ToString("MMMM dd, yyyy"));
        Console.WriteLine("Custom Format 3: " + now.ToString("dddd, MM dd yyyy HH:mm:ss"));

        // Print the date from 7 days prior and 7 days from the current date

        DateTime sevenDaysAgo = now.AddDays(-7);
        DateTime sevenDaysFromNow = now.AddDays(7);
        Console.WriteLine("7 Days Ago: " + sevenDaysAgo.ToShortDateString());
        Console.WriteLine("7 Days From Now: " + sevenDaysFromNow.ToShortDateString());

        // Validate date entered by a user as String

        Console.WriteLine("Enter a date (MM/dd/yyyy): ");
        string userInput = Console.ReadLine();
        DateTime parsedDate;
        bool isValidDate = DateTime.TryParseExact(userInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        if (isValidDate)
        {
            Console.WriteLine("The entered date is valid: " + parsedDate.ToShortDateString());
        }
        else
        {
            Console.WriteLine("The entered date is invalid.");
        }

        // calculate the hours, days, and minutes between two dates
        Console.WriteLine("Enter the first date (MM/dd/yyyy): ");
        string firstDateString = Console.ReadLine();
        Console.WriteLine("Enter the second date (MM/dd/yyyy): ");
        string secondDateString = Console.ReadLine();

        DateTime firstDate;
        DateTime secondDate;
        bool isFirstDateValid = DateTime.TryParseExact(firstDateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out firstDate);
        bool isSecondDateValid = DateTime.TryParseExact(secondDateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out secondDate);

        if (isFirstDateValid && isSecondDateValid)
        {
            TimeSpan difference = secondDate - firstDate;
            Console.WriteLine($"Difference: {difference.TotalDays} days, {difference.TotalHours} hours, {difference.TotalMinutes} minutes");
        }
        else
        {
            Console.WriteLine("One or both of the entered dates are invalid.");
        }

        /*Given user input, transform the input to all upper and all lowercase and print the results.*/

        Console.WriteLine("Enter a string: ");
        String input = Console.ReadLine();

        Console.WriteLine(input.ToUpper());
        Console.WriteLine(input.ToLower());

        /*Given a user input string and a user input character, 
        *transform all of the spaces in the input string to instances of that character*/

        Console.WriteLine("Enter a new string with spaces: ");
        input = Console.ReadLine();
        Console.WriteLine("Enter a character: ");
        char c = Console.ReadLine().ToCharArray()[0];

        Console.WriteLine(input.Replace(' ', c));

        /*Modify a previous example to detect if an input string is an empty string or all blank characters 
        *and print a message if that is true.*/

        Console.WriteLine("Enter a new string that could be empty: ");
        input = Console.ReadLine();

        if(input.Equals(""))
        {
            Console.WriteLine("String is empty bro");
        }
        else
        {
            Console.WriteLine("String is not empty bro");
        }

        /*Detect if a user input value is all numbers and print a message to that effect.
        *There are several ways to accomplish this–Regex, 
        *Int/Float.TryParse, or looping through the string and checking each character. 
        *Discuss the advantages/disadvantages to doing things each particular way. */

        Console.WriteLine("Enter a new string that could have all numbers: ");
        input = Console.ReadLine();

        bool isAllDigits = int.TryParse(input, out _);

        Console.WriteLine(isAllDigits ? "The string is all numbers" : "The string is not all numbers");

        /*Input the day, month, and year, then use String.Format() to insert those values into a string and print the result. */

        Console.WriteLine("Enter the Day: ");
        int day = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Month: ");
        int month = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Year: ");
        int year = int.Parse(Console.ReadLine());

        String formatted = String.Format($"{month:D2}/{day:D2}/{year}");
        Console.WriteLine("Formatted Date: " + formatted);

        /*Given user input: 
        *a) remove all leading/trailing zeroes using String.TrimStart()/TrimEnd(), 
        *b) detect if the resulting string is numeric, and 
        *c) output the resulting string and whether or not it’s numeric.*/

        Console.WriteLine("Enter a new string that could have all numbers and/or spaces at the beginning or end: ");
        input = Console.ReadLine();

        input = input.Trim();

        isAllDigits = int.TryParse(input, out _);
        Console.WriteLine($"The string {input} " + (isAllDigits? "is numeric" : "is not numeric"));

        /*Use String.Format() to print numbers between 0 and 100 (inclusive) in a 10 column table, 
         * with all numbers zero padded to 3 characters. 
         * Bonus: allow the user to specify how many numbers they want to print, 
         * the number of columns, and the number of padding spaces. 
         * Be sure to handle checking for bad input! */

        Console.Write("Enter how many numbers you want: ");
        int totalNumbers = int.Parse(Console.ReadLine());

        Console.Write("Enter how many columns you want: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter how many padding spaces you want: ");
        int padding = int.Parse(Console.ReadLine());

        int rows = (int)Math.Ceiling((double)totalNumbers / (double)columns);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int number = i * columns + j;
                if(number <= totalNumbers)
                {
                    //string formattedNumber = "{" + number.ToString() + ":D" + padding.ToString() + "}";
                    string s = number.ToString();
                    Console.Write(s.PadLeft(padding, '0'));
                }
                if(j < columns - 1)
                {
                    Console.Write(new String(' ', padding));
                }

            }
            Console.WriteLine();
        }

    }
}