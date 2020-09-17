using System;

// Create a new Visual C# Console App using .NET Framework project and name it "ConsoleApplication."
namespace ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("********************************************************************\n" + 
                "This part of the program displays the developer's name and location.\n" +
                "It also displays today's date and the number of days until christmas.\n" +
                "********************************************************************");


            // Store two variables: Your name and Your location(state or country)
            string name, location;

            //Store Christmas date
            DateTime christmasDate = new DateTime(2020, 12, 25);

            //Get name from user
            Console.Write("\nWhat is your name? ");
            name = Console.ReadLine();

            //Get location from user
            Console.Write($"\nHi {name}! Where are you from? ");
            location = Console.ReadLine();

            // Output a friendly message
            Console.WriteLine($"I have never been to {location}. I bet it is a wonderful place to live. Press any key to continue...");

            Console.ReadKey();

            // Output name and location
            Console.WriteLine("\nThe line below is coded using String Interpolation:");

            Console.WriteLine($"My name is {name}. I am from {location}.");

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            Console.WriteLine("\n\n\nPress any key to continue...");

            Console.ReadKey();

            // Output today's date
            Console.WriteLine($"\nToday's date is {DateTime.Now.ToString("MMMM dd, yyyy")}.");

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            // Calculate remaining days until christmas
            double daysToChristmas = christmasDate.Subtract(DateTime.Today).TotalDays;

            // Output number of days until christmas
            Console.WriteLine($"\nHooray! We have {daysToChristmas} days until christmas.");

            Console.WriteLine("\nPress any key to continue...");

            Console.ReadKey();

            // Add the program example from section 2.1 in the C# Programming Yellow Book by Rob Miles.
            Console.WriteLine("\n\n******************************************************************************************\n" +
                "This part of the program accepts the width and height of a window and then print out the\n" +
                "amount of wood and glass required to make a window that will fit in a hole of that size.\n" +
                "******************************************************************************************");


            // Declare variables
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            // The program accepts the width of the window
            Console.Write("\nEnter the width of the window: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            // The program accepts the height of the window
            Console.Write("\nEnter the height of the window: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            // Calculate the amount of wood and glass required
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            // Output the length pf wood and area of glass required
            Console.WriteLine($"\nThe length of the wood is  {woodLength} feet");
            Console.WriteLine($"The area of the glass is  {glassArea} square metres");

            // Do not automatically terminate the console
            Console.WriteLine("\nPress any key to close the console application");
            Console.ReadKey();
        }
    }
}
