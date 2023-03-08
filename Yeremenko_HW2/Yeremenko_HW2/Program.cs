namespace Yeremenko_HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Part 1: Arithmetic operations *****");
            Console.Write("Input the first int number A = ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the second int number (the number shouldn't be equal to 0) B = ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine($"A + B = {num1+num2}");

            Console.WriteLine();
            Console.WriteLine($"A / B = {(double)num1 / num2}");

            Console.WriteLine();
            Console.WriteLine($"-1 + 4 * 6 = {-1 + 4 * 6}");
            Console.WriteLine($"(35 + 5) % 7 = {(35 + 5) % 7}");
            Console.WriteLine($"14 + -4 * 6 / 11 = {14 + -4 * (double)6 / 11}");
            Console.WriteLine($"2 + 15 / 6 * 1 - 7 % 2 = {2 + (double)15 / 6 * 1 - 7 % 2}");

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("***** Part 2: Swap two numbers *****");
            Console.WriteLine();
            Console.Write("Input the First (int) Number A = ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the Second (int) Number B = ");
            num2 = Convert.ToInt32(Console.ReadLine());
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("After Swapping");
            Console.WriteLine($"First Number A = {num1}, Second Number B = {num2}");

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("***** Part 3: Multiplication of three numbers *****");
            Console.WriteLine();
            Console.Write("Input the First (int) Number to multiply: A = ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the Second (int) Number to multiply: B = ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the Third (int) Number to multiply: C = ");
            int num3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The multiplication result is: {num1 * num2 * num3}");

        }
    }
}