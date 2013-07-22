/* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 
32-bit unsigned integer. */

using System;

class ExchangeGivenBits
{
    static void Main()
    {
        int intUserNumber = 0;
        Console.Write("Please enter an integer number (n) for the \"Exchange Bits\" program: ");
        intUserNumber = int.Parse(Console.ReadLine());

        int bitPosition1 = 0;
        int bitPosition2 = 0;
        int bitNumber = 0;
        Console.Write("Please enter number for the first group bit position (p): ");
        bitPosition1 = int.Parse(Console.ReadLine());
        Console.Write("Please enter number for the second group bit position (q): ");
        bitPosition2 = int.Parse(Console.ReadLine());
        Console.Write("Please enter how many bits (k) do you want to change: ");
        bitNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The binary input number is:   {0}", (Convert.ToString(intUserNumber, 2).PadLeft(32, '0')));

        int i = bitPosition1;   // номер на първия бит за смяна
        int j = bitPosition2;   // номер на втория бит за смяна
        int n = bitNumber;      // броя на битовете за смяна
        int b = intUserNumber;  // числото от което ще се сменят
        long r;                 // тук ще пази резултата

        long x = ((b >> i) ^ (b >> j)) & ((1U << n) - 1); 
        r = b ^ ((x << i) | (x << j));
        Console.WriteLine("The binary input number is:   {0}", (Convert.ToString(r, 2).PadLeft(32, '0')));
        Console.WriteLine("The result number in decimal system is: {0}", r);
    }
}

