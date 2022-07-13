using System;
using board;
using chess;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            Board tab = new Board(8, 8);

            tab.setPiece(new King(tab, Color.Preta), new Position(0, 0));
            tab.setPiece(new Rook(tab, Color.Preta), new Position(2, 4));
            tab.setPiece(new Rook(tab, Color.Branca), new Position(3, 0));
            tab.setPiece(new Rook(tab, Color.Branca), new Position(2, 1));
            Screen.printBoard(tab);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
