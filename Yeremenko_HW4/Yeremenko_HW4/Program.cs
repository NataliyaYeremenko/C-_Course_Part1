using System.Drawing;
using System.Threading;

namespace Yeremenko_HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Part 1: Find the largest value from three integer numbers *****");
            int[] numb = new int[3];
            InputIntNumbersFromConsole(3, out numb);
            Console.WriteLine($"The largest value from three integer numbers ({numb[0]}, {numb[1]}, {numb[2]}) " +
                              $"is: {FindTheLargestValueFromThreeInt(numb[0], numb[1], numb[2])}");
            Console.WriteLine();

            Console.WriteLine("***** Part 2: Find the lowest value from three integer numbers *****");
            InputIntNumbersFromConsole(3, out numb);
            Console.WriteLine($"The lowest value from three integer numbers ({numb[0]}, {numb[1]}, {numb[2]}) " +
                              $"is: {FindTheLowestValueFromThreeInt(numb[0], numb[1], numb[2])}");
            Console.WriteLine();

            Console.WriteLine("***** Part 3: Find the nearest to 20 value from two integer numbers *****");
            InputIntNumbersFromConsole(2, out numb);
            Console.WriteLine($"The nearest (return 0 if two numbers are the same) to 20 value from two integer numbers ({numb[0]}, {numb[1]}) " +
                              $"is: {FindTheNearestTo20ValueFromTwoInt(numb[0], numb[1])}");
            Console.WriteLine();
            
            Console.WriteLine("***** Part 4: Find the sum of all the elements of an array of integers *****");
            Console.WriteLine("Enter:\r\n  1 - to input array elements through the console;\r\n  0 - to calculate the sum in the random array");
            int decision = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the array size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            if (size > 0)
            {
                if (decision == 0)
                {
                    Console.Write($"The sum of all the elements of an random array");
                    arr = GenerateRandomArray(size);
                    PrintArrayElements(arr);
                    Console.WriteLine($" is equal to: {GetSumOfArraysValues(arr)}");
                }
                else
                {
                    arr = InputArrayFromConsole(size);
                    Console.Write($"The sum of all the elements of an inputted array ");
                    PrintArrayElements(arr);
                    Console.WriteLine($" is equal to: {GetSumOfArraysValues(arr)}");
                }
            }
            else
            {
                Console.WriteLine("Incorrect size (should me more than 0)");
            }
            
            Console.WriteLine();

            Console.WriteLine("***** Part 5: Find the largest of all the elements of an array of integers *****");
            Console.WriteLine("Enter:\r\n  1 - to input array elements through the console;" +
                "\r\n  0 - to find the largest value in the random array");
            decision = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the array size: ");
            size = Convert.ToInt32(Console.ReadLine());
            if (size > 0)
            {
                if (decision == 0)
                {
                    Console.Write($"The largest of all the elements of an random array");
                    arr = GenerateRandomArray(size);
                    PrintArrayElements(arr);
                    Console.WriteLine($" is equal to: {GetMaxOfArraysValues(arr)}");
                }
                else
                {
                    arr = InputArrayFromConsole(size);
                    Console.Write($"The largest of all the elements of an inputted array ");
                    PrintArrayElements(arr);
                    Console.WriteLine($" is equal to: {GetMaxOfArraysValues(arr)}");
                }
            }
            else
            {
                Console.WriteLine("Incorrect size (should me more than 0)");
            }
        }

        static int FindTheLargestValueFromThreeInt(int num1, int num2, int num3)
        {
            if ((num1 >= num2) && (num1 >= num3)) return num1;
            else if ((num2 >= num1) && (num2 >= num3)) return num2;
            else return num3;
        }

        static int FindTheLowestValueFromThreeInt(int num1, int num2, int num3)
        {
            if ((num1 <= num2) && (num1 <= num3)) return num1;
            else if ((num2 <= num1) && (num2 <= num3)) return num2;
            else return num3;
        }

        static int FindTheNearestTo20ValueFromTwoInt(int num1, int num2)
        {
            if (Math.Abs(20-num1) > Math.Abs(20 - num2)) return num2;
            else if (Math.Abs(20 - num2) > Math.Abs(20 - num1)) return num1;
            else return 0;
        }

        static void PrintArrayElements(int[] ar)
        {
            Console.Write("{");
            for (int i=0; i<ar.Length-1; i++)
            {
                Console.Write("" +ar[i]+"; ");
            }
            Console.Write(""+ar[ar.Length - 1]+"}");
        }
        static void InputIntNumbersFromConsole(int numCount, out int[] arr)
        {
            arr = new int[numCount];
            for (int i = 1; i <= numCount; i++)
            {
                Console.Write($"Input '{i}' int number: ");
                arr[i-1] = Convert.ToInt32(Console.ReadLine());
            }
        }
        static int[] InputArrayFromConsole(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"arr[{i}] = ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
         }
        static int[] GenerateRandomArray(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = (new Random()).Next(-100,100);
            }
            return arr;
        }

        static int GetSumOfArraysValues(int[] ar)
        {
            int sum = 0;
            foreach (int i in ar)
            {
                sum+= i;
            }
            return sum;
        }

        static int GetMaxOfArraysValues(int[] ar)
        {
            int max = ar[0];
            for (int i=1; i<ar.Length; i++)
            {
                if (max < ar[i]) max = ar[i];
            }
            return max;
        }
    }
}