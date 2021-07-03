using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment02
{
    class Program
    {

        public static int MenuOption()
        {
            string userSelelction = "";
            bool selectionFlag = false;
            while (selectionFlag == false)
            {
                Console.WriteLine("1 = Enter Triangle dimensions");
                Console.WriteLine("2 = Exit\n");

                Console.WriteLine("Please select an option, by entering a number:");
                userSelelction = Console.ReadLine();
                if (userSelelction != "1" &&
                    userSelelction != "2")
                {
                    Console.WriteLine("This selection is invalid please enter the correct option from the menu:");

                }
                else { selectionFlag = true; }
            }

            return int.Parse(userSelelction);
        }

        public static double ValidateUserInput(string chosenLengthOfTriangle)
        {
            double aNumber = 1;
            bool isValid = false;

            while (isValid == false)
            {
                Console.Write($"Please enter the length of {chosenLengthOfTriangle}:");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                bool result = double.TryParse(userInput, out aNumber);

                if (result == false || aNumber < 1)
                {
                    Console.WriteLine("That's not a valid input please,  try again.\n");
                }

                else
                {
                    isValid = true;
                    Console.WriteLine($"Current {chosenLengthOfTriangle} has been set to: {aNumber}.\n");
                }
            }

            return aNumber;
        }
        static void Main(string[] args)
        {
            TriangleSolver triangleObj = new TriangleSolver();

            int selection;
            double firstSide, secondSide, thirdSide;
            selection = MenuOption();

            while (selection != 2)
            {
                firstSide = ValidateUserInput("first side");
                secondSide = ValidateUserInput("second side");
                thirdSide = ValidateUserInput("third side");
                Console.WriteLine($"Entered sides of a triangle, first side: {firstSide}, second side: {secondSide} and third side: {thirdSide}.\n");
                TriangleSolver triangleObject2 = new TriangleSolver(firstSide, secondSide, thirdSide);
                triangleObj = triangleObject2;
                Console.WriteLine(triangleObj.Analyze());
                selection = MenuOption();
            }
        }
    }
}
