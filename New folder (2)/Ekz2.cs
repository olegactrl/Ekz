using System;

class Program
{
    static void Main()
    {
        Func<int, int, int, int> average = delegate (int a, int b, int c)
        {
            return (a + b + c) / 3;
        };

        int num1 = 1;
        int num2 = 2;
        int num3 = 3;

        double result = average(num1, num2, num3);

        Console.WriteLine($"Avarage = {result}");

        Console.ReadLine();
    }
}