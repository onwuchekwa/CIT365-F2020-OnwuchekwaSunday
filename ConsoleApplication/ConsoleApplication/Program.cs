using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Create a new Visual C# Console App using .NET Framework project and name it "ConsoleApplication."
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************\n" + 
                "This part of the program displays the developer's name and location.\n" +
                "It also displays today's date and the number of days until christmas.\n" +
                "********************************************************************");


            // Store two variables: Your name and Your location(state or country)
            String name = "Sunday Ogbonnaya Onwuchekwa", location = "Abia State, Nigeria";

            //Store Christmas date
            DateTime christmasDate = new DateTime(2020, 12, 25);            

            // Output name and location
            Console.WriteLine($"\nMy name is {name}.");
            Console.WriteLine("I am from {0}.", location);

            // Output today's date
            Console.WriteLine("\nToday's date is {0}.", DateTime.Now.ToString("MMMM dd, yyyy"));

            // Calculate remaining days until christmas
            double daysToChristmas = christmasDate.Subtract(DateTime.Today).TotalDays;

            // Output number of days until christmas
            Console.WriteLine($"\nHooray! We have {daysToChristmas} days until christmas.");

            // Add the program example from section 2.1 in the C# Programming Yellow Book by Rob Miles.
            Console.WriteLine("\n\n******************************************************************************************\n" +
                "This part of the program accepts the width and height of a window and then print out the\n" +
                "amount of wood and glass required to make a window that will fit in a hole of that size.\n" +
                "******************************************************************************************");


            // Declare variables
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            // The program accepts the width of the window
            Console.WriteLine("\nEnter the width of the window");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            // The program accepts the height of the window
            Console.WriteLine("\nEnter the height of the window");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            // Calculate the amount of wood and glass required
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            // Output the length pf wood and area of glass required
            Console.WriteLine("\nThe length of the wood is " + woodLength + " feet");
            Console.WriteLine("The area of the glass is " + glassArea + " square metres");

            // Do not automatically terminate the console
            Console.ReadKey();
        }
    }
}
