using System;

namespace Lab1DebugTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuselection = 0;

            int[] numbersentered = new int[5];
            Console.WriteLine("Enter five numbers");
            for (int i = 0; i < 5; i++)
            {
                numbersentered[i] = ReadNumber();
            }

            while (menuselection != -1)
            {
                menuselection = RunMenu();
                switch (menuselection)
                {
                    case 0:
                    case 5:
                        Console.WriteLine("Enter five numbers");
                        for (int i = 1; i < 5; i++)
                        {
                            numbersentered[i] = ReadNumber();
                        }
                        break;
                    case 1:
                        Console.WriteLine("The product of all number is: {0:D}", Sum(ref numbersentered));
                        break;
                    case 2:
                        Console.WriteLine("The product of all number is: {0:D}", Product(ref numbersentered));
                        break;
                    case 3:
                        Console.WriteLine("The smalest number entered is: {0:D}", FindSmalest(ref numbersentered));
                        break;
                    case 4:
                        Console.WriteLine("The largest number entered is: {0:D}", FindLargest(ref numbersentered));
                        break;
                    default:
                        menuselection = -1;
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the menu items.
        /// </summary>
        /// <returns>Returns the menu item selected, if the user enters any other character than one of the menu item number it returns -1</returns>
        static int RunMenu()
        {
            int menuselection = -1;

            Console.WriteLine("1. Find the Sum of all numbers");
            Console.WriteLine("2. Find the Product of all numbers");
            Console.WriteLine("3. Find the smallest of all numbers");
            Console.WriteLine("4. Find the largest number provided");
            Console.WriteLine("5. Enter new numbers");
            int.TryParse(Console.ReadLine(), out menuselection);

            return menuselection;
        }

        /// <summary>
        /// Reads a number and verifies if it is valid, if not then it shall ask the user for another valid number. 
        /// </summary>
        /// <remarks>The method shall only exit when a user enters a valid number </remarks>
        /// <returns>Returns the number read</returns>
        static int ReadNumber()
        {
            int result = 0;
            string str_num = "";
            bool numberread = false;
            do
            {
                str_num = Console.ReadLine();
                numberread = int.TryParse(str_num, out result);
                if (!numberread)
                {
                    Console.WriteLine("This is not a number between {0:d} and {1:d} numbers. Please enter a valid number:", int.MinValue, int.MaxValue);
                }
            } while (!numberread);

            return result;
        }

        /// <summary>
        /// Calculates the sum of all numbers in the inputted array
        /// </summary>
        /// <param name="numbers">A reference of the array of integers</param>
        /// <returns>The sum of all integers in the inputted array</returns>
        static int Sum(ref int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        /// <summary>
        /// Calculates the product of all numbers in the inputted array
        /// </summary>
        /// <param name="numbers">A reference of the array of integers</param>
        /// <returns>The product of all integers in the inputted array</returns>
        static int Product(ref int[] numbers)
        {
            int Product = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    Product = numbers[0];
                }else{

                Product *= numbers[i];
                }
            }
            return Product;
        }

        /// <summary>
        /// Searches throught the array and finds the smallest number within the inputted array
        /// </summary>
        /// <param name="numbers">A reference of the array of integers</param>
        /// <returns>The smallest number found</returns>
        static int FindSmalest(ref int[] numbers)
        {
            int smallest = numbers[0];
            for (int i = numbers.Length; i <= 0; i--)
            {
                if (numbers[i] > smallest)
                    smallest = numbers[i];
            }
            return smallest;
        }

        /// <summary>
        /// Searches throught the array and finds the largest number within the inputted array 
        /// </summary>
        /// <param name="numbers">A reference of the array of integers</param>
        /// <returns>The largest number found</returns>
        static int FindLargest(ref int[] numbers)
        {
            int largest = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                    largest = numbers[i];
            }
            return largest;
        }
    }
}
