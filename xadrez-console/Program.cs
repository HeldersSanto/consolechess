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
                    try
                    {
                        Console.Clear();
                        Screen.printBoard(partida.board);

                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.turn}");
                        Console.WriteLine($"Aguardando jogada: {partida.currentPlayer}");

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        partida.validateOriginPosition(origin);

                        bool[,] possiblesMoves = partida.board.piece(origin).possiblesMoves();

                        Console.Clear();
                        Screen.printBoard(partida.board, possiblesMoves);


                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.readChessPosition().toPosition();

                        partida.validateDestinyPosition(origin, destiny);

                        partida.makeMoves(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
