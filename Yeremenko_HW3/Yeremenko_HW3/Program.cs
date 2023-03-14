using System.Security.Cryptography.X509Certificates;

namespace Yeremenko_HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Part 1: Check two given integers *****");
            Console.Write("Input the first integer number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the second integer number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Check if one is positive and one is negative: ");
            Console.WriteLine(((num1 > 0 && num2 < 0) || (num1 < 0 && num2 > 0)) ? "True" : "False");
            Console.WriteLine();

            Console.WriteLine("***** Part 2: Check the sum of two given integers *****");
            Console.Write("Input the first integer number: A = ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the second integer number: B = ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Check if A=20 or B=20 or A+B=20: ");
            Console.WriteLine((num1 == 20 || num2 == 20 || (num1 + num2 == 20)) ? "True" : "False");
            Console.WriteLine();
            
            Console.WriteLine("***** Part 3: Print the odd numbers from 1 to 99 (one number per line) *****");
            int num = 1;
            while (num <= 99)
            {
                if (num % 2 != 0) Console.WriteLine(num);
                ++num;
            }
            Console.WriteLine();
            
            Console.WriteLine("***** Part 4: Compute the sum of the first 500 prime numbers *****");
            int primeNum = 2;
            bool primeCondition = true;
            int primeCount = 1;
            int sumOfPrimes = 0;
            Console.Write("First 500 prime numbers: ");
            while (primeCount <= 500)
            {
                for(int i = primeNum-1; i > 1; i--)
                    if (primeNum % i == 0)
                    {
                        primeCondition = false;
                        break;  
                    }
                if (primeCondition) 
                { 
                    sumOfPrimes += primeNum;
                    Console.Write("" + primeNum + ";  ");
                    ++primeCount;
                }
                primeCondition = true;
                ++primeNum;
            }
            Console.WriteLine();
            Console.WriteLine($"The sum of the first 500 prime numbers: {sumOfPrimes}");
            Console.WriteLine();
            
            Console.WriteLine("***** Part 5: Compute the sum of the digits of an integer number *****");
            Console.Write("Input a number (integer): ");
            int num3 = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            int digitCount = num3.ToString().Length;
            int sumOfDigits = 0;
            while (digitCount >= 1) 
            {
                sumOfDigits += num3 % 10;
                num3 /= 10;
                --digitCount;
            }
            Console.WriteLine($"The sum of the digits of the said integer: {sumOfDigits}");
            Console.WriteLine();
        }
    }
}