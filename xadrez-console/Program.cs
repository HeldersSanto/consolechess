using System;
using board;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            Screen.printBoard(tab);

            Console.ReadLine();
        }
    }
}
