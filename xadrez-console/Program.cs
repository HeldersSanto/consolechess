using System;
using board;
using chess;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            tab.setPiece(new King(tab, Color.Preta), new Position(0, 0));
            Screen.printBoard(tab);

            Console.ReadLine();
        }
    }
}
