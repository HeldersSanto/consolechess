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
                for (int j = 0; j<tab.colunas; j++)
                {

                    if (tab.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
