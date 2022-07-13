using System;
using board;
namespace xadrez_console
{
    class Screen
    {
        public static void printBoard(Board tab)
        {
            for (int i = 0; i<tab.linhas; i++)
            {
                Console.Write(" " + (8 - i) + " ");
                for (int j = 0; j<tab.colunas; j++)
                {

                    if (tab.piece(i, j) == null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" ");
                        printPiece(tab.piece(i, j));
                        Console.Write(" ");

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("    a  b  c  d  e  f  g  h  ");
        }
        public static void printPiece(Piece piece)
        {
            if(piece.color == Color.Branca)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
