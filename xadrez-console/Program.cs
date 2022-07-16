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
                ChessGame partida = new ChessGame();

                while (!partida.gameOver)
                {
                    Console.Clear();
                    Screen.printBoard(partida.board);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Position origin = Screen.readChessPosition().toPosition();


                    bool[,] possiblesMoves = partida.board.piece(origin).possiblesMoves();

                    Console.Clear();
                    Screen.printBoard(partida.board, possiblesMoves);


                    Console.Write("Destino: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    partida.execMovement(origin, destiny);
                }

                Screen.printBoard(partida.board);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
