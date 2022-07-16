using System;
using board;
using chess;

namespace xadrez_console
{
    class Screen
    {
        public static void printBoard(Board tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(" " + (8 - i) + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    printPiece(tab.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("    a  b  c  d  e  f  g  h  ");
        }

        public static void printBoard(Board tab, bool[,] possiblesMoves)
        {
            ConsoleColor originalBG = Console.BackgroundColor;
            ConsoleColor newBG = ConsoleColor.DarkCyan;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(" " + (8 - i) + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (possiblesMoves[i, j])
                    {
                        Console.BackgroundColor = newBG;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBG;
                    }
                    printPiece(tab.piece(i, j));
                    Console.BackgroundColor = originalBG;
                }
                Console.WriteLine();
            }
            Console.WriteLine("    a  b  c  d  e  f  g  h  ");
            Console.BackgroundColor = originalBG;
        }

        public static ChessPositions readChessPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1] + "");

            return new ChessPositions(column, line);
        }
        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write(" - ");
            }
            else
            {

                if (piece.color == Color.Branca)
                {
                    Console.Write(" ");
                    Console.Write(piece);
                    Console.Write(" ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" ");
                    Console.Write(piece);
                    Console.Write(" ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}
