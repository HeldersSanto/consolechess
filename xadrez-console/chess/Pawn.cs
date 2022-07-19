using board;
namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnimy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }
        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possiblesMoves()
        {
            bool[,] mat = new bool[board.linhas, board.colunas];

            Position pos = new Position(0, 0);
            if (color == Color.Branca)
            {
                pos.definePosition(position.linha - 1, position.coluna);
                if (board.isValidPosition(pos) && free(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha - 2, position.coluna);
                if (board.isValidPosition(pos) && free(pos) && numberOfMoves == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha - 1, position.coluna - 1);
                if (board.isValidPosition(pos) && hasEnimy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha - 1, position.coluna + 1);
                if (board.isValidPosition(pos) && hasEnimy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.definePosition(position.linha + 1, position.coluna);
                if (board.isValidPosition(pos) && free(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha + 2, position.coluna);
                if (board.isValidPosition(pos) && free(pos) && numberOfMoves == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha + 1, position.coluna - 1);
                if (board.isValidPosition(pos) && hasEnimy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definePosition(position.linha + 1, position.coluna + 1);
                if (board.isValidPosition(pos) && hasEnimy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            return mat;
        }
    }
}
