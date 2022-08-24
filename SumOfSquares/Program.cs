using System;

namespace SumOfSquares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var programRunning = true;
            var input = 0;
            var sum = new SumOfSquaresCalc();

            //Program loop
            while (programRunning)
            {
                Console.WriteLine("Please enter a number to get sum of squares: ");
                var consoleInput = Console.ReadLine();

                while(!int.TryParse(consoleInput, out input))
                {
                    Console.WriteLine("Not a valid number, please try again: ");
                    consoleInput = Console.ReadLine();
                }
                
                var result = sum.Decompose(input);

                if (result != null)
                {
                    Console.WriteLine($"Result is: [{ string.Join(",", result) }]");
                }
                else
                {
                    Console.WriteLine("This value has no sum of squares");
                }
                
                Console.WriteLine("Would you like to continue?\nn to quit or any key to continue");
                
                if(Console.ReadLine().ToLower() == "n")
                {
                    programRunning = false;
                }
            }
        }
    }


    public class SumOfSquaresCalc
    {

        //Function to decompose the sum of squares
        public int[] Decompose(int n)
        {
            var result = DecomposeRecur(n - 1, n * n);
            if (result == null)
            {
                return null;
            }
            return result.ToArray<int>();
        }


        //helper function to decompose recursivley to strictly increasing sequence
        private List<int> DecomposeRecur(int i, int total)
        {
            if (total == 0)
            {
                return new List<int>();
            }
            if (i <= 0 || total < 0)
            {
                return null;
            }
            List<int> sublist = DecomposeRecur(i - 1, total - i * i);
            if (sublist != null)
            {
                sublist.Add(i);
                return sublist;
            }
            return DecomposeRecur(i - 1, total);
        }
    }
}