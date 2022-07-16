using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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
        public void makeMoves(Position origin, Position destiny)
        {
            execMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça nessa posição de origem!");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("A peça escolhida não é sua!");
            }
            if (!board.piece(pos).hasPossibleMoves()) {
                throw new BoardException("Não existe movimentos possiveis para essa peça!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("A peça não pode ser movida ao lugar selecionado!");
            }
        }
        private void changePlayer()
        {
            if(currentPlayer == Color.Branca)
            {
                currentPlayer = Color.Preta;
            }
            else
            {
                currentPlayer = Color.Branca;
            }
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
