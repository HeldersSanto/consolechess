using System.Collections.Generic;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool gameOver { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            setPieceOnBoard();
            gameOver = false;
        }

        public void execMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incNumerOfMoves();
            Piece capturedPiece = board.removePiece(destiny);
            board.setPiece(p, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
        }
        public void makeMoves(Position origin, Position destiny)
        {
            execMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça nessa posição de origem!");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("A peça escolhida não é sua!");
            }
            if (!board.piece(pos).hasPossibleMoves())
            {
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

        public HashSet<Piece> piecesCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in capturedPieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(piecesCaptured(color));
            return aux;
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.Branca)
            {
                currentPlayer = Color.Amarela;
            }
            else
            {
                currentPlayer = Color.Branca;
            }
        }

        public void setNewPiece(char coluna, int linha, Piece piece)
        {
            board.setPiece(piece, new ChessPositions(coluna, linha).toPosition());
            pieces.Add(piece);
        }
        private void setPieceOnBoard()
        {
            setNewPiece('c', 1, new Rook(board, Color.Branca));
            setNewPiece('c', 2, new Rook(board, Color.Branca));
            setNewPiece('d', 2, new Rook(board, Color.Branca));
            setNewPiece('e', 2, new Rook(board, Color.Branca));
            setNewPiece('e', 1, new Rook(board, Color.Branca));
            setNewPiece('d', 1, new King(board, Color.Branca));


            setNewPiece('c', 7, new Rook(board, Color.Amarela));
            setNewPiece('c', 8, new Rook(board, Color.Amarela));
            setNewPiece('d', 7, new Rook(board, Color.Amarela));
            setNewPiece('e', 7, new Rook(board, Color.Amarela));
            setNewPiece('e', 8, new Rook(board, Color.Amarela));
            setNewPiece('d', 8, new King(board, Color.Amarela));
        }
    }
}
