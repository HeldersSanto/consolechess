using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool gameOver { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            setPieceOnBoard();
            gameOver = false;
        }

        public void execMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incNumerOfMoves();
            Piece capturedPiece = board.removePiece(destiny);
            board.setPiece(p, destiny);
        }

        private void setPieceOnBoard()
        {
            board.setPiece(new Rook(board, Color.Branca), new ChessPositions('c', 1).toPosition());
            board.setPiece(new Rook(board, Color.Branca), new ChessPositions('c', 2).toPosition());
            board.setPiece(new Rook(board, Color.Branca), new ChessPositions('d', 2).toPosition());
            board.setPiece(new Rook(board, Color.Branca), new ChessPositions('e', 2).toPosition());
            board.setPiece(new Rook(board, Color.Branca), new ChessPositions('e', 1).toPosition());
            board.setPiece(new King(board, Color.Branca), new ChessPositions('d', 1).toPosition());

            board.setPiece(new Rook(board, Color.Amarela), new ChessPositions('c', 7).toPosition());
            board.setPiece(new Rook(board, Color.Amarela), new ChessPositions('c', 8).toPosition());
            board.setPiece(new Rook(board, Color.Amarela), new ChessPositions('d', 7).toPosition());
            board.setPiece(new Rook(board, Color.Amarela), new ChessPositions('e', 7).toPosition());
            board.setPiece(new Rook(board, Color.Amarela), new ChessPositions('e', 8).toPosition());
            board.setPiece(new King(board, Color.Amarela), new ChessPositions('d', 8).toPosition());
        }
    }
}
