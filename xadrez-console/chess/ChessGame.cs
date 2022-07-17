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
        public bool check { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            setPieceOnBoard();
            check = false;
            gameOver = false;
        }

        public Piece execMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incNumerOfMoves();
            Piece capturedPiece = board.removePiece(destiny);
            board.setPiece(p, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMoves(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decNumerOfMoves();
            if (capturedPiece != null)
            {
                board.setPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            board.setPiece(p, origin);
        }
        public void makeMoves(Position origin, Position destiny)
        {
            Piece capturedPiece = execMovement(origin, destiny);
            if (isInCheck(currentPlayer))
            {
                undoMoves(origin, destiny, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }
            if (isInCheck(adversaryColor(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckmate(adversaryColor(currentPlayer)))
            {
                gameOver = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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

        private Color adversaryColor(Color color)
        {
            if (color == Color.Branca)
            {
                return Color.Amarela;
            }
            else
            {
                return Color.Branca;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("Não tem rei");
            }
            foreach (Piece x in piecesInGame(adversaryColor(color)))
            {
                bool[,] mat = x.possiblesMoves();
                if (mat[K.position.linha, K.position.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color)
        {
            if (isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possiblesMoves();
                for (int i = 0; i < board.linhas; i++)
                {
                    for (int j = 0; j < board.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = execMovement(origin, destiny);
                            bool stillInCheck = isInCheck(color);
                            undoMoves(origin, destiny, capturedPiece);
                            if (!stillInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void setNewPiece(char coluna, int linha, Piece piece)
        {
            board.setPiece(piece, new ChessPositions(coluna, linha).toPosition());
            pieces.Add(piece);
        }
        private void setPieceOnBoard()
        {
            setNewPiece('c', 1, new Rook(board, Color.Branca));
            setNewPiece('h', 7, new Rook(board, Color.Branca));
            setNewPiece('g', 7, new Rook(board, Color.Branca));
            setNewPiece('d', 1, new King(board, Color.Branca));

            
            setNewPiece('a', 8, new King(board, Color.Amarela));
        }
    }
}
