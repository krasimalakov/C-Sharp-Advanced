namespace _02.JediGalaxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public static class JediGalaxy
    {
        public static void Main()
        {
            var size =Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = size[0];
            var cols = size[1];
            var matrix = new int[rows, cols];
            BigInteger power = 0;
            matrix.Fill();
            while (true)
            {
                var input= Console.ReadLine();
                if (input == "Let the Force be with you")
                {
                    break;
                }

                var ivoStart= input.Split().Select(int.Parse).ToArray();
                var evilStart= Console.ReadLine().Split().Select(int.Parse).ToArray();
                var col = evilStart[1];
                for (int row = evilStart[0]; row >= 0; row--)
                {
                    if (col >= 0 && col<cols && row<rows)
                    {
                        matrix[row, col]=0;
                    }
                    col--;
                }

                col = ivoStart[1];
                for (int row = ivoStart[0]; row >=0 ; row--)
                {
                    if (col >= 0 && col < cols && row < rows)
                    {
                        power+=matrix[row, col];
                    }
                    col++;
                }
            }
            Console.WriteLine(power);
        }
        public static void Fill(this int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = row * cols + col;
                }
            }
        }
    }
}