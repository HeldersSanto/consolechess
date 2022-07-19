using board;
namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "D";
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

            //ne
            pos.definePosition(position.linha - 1, position.coluna + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha - 1, pos.coluna + 1);
            }

            //no
            pos.definePosition(position.linha - 1, position.coluna - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha - 1, pos.coluna - 1);
            }

            //so
            pos.definePosition(position.linha + 1, position.coluna - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha + 1, pos.coluna - 1);
            }

            //se
            pos.definePosition(position.linha + 1, position.coluna + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha + 1, pos.coluna + 1);
            }

            //acima
            pos.definePosition(position.linha - 1, position.coluna);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha - 1, pos.coluna);
            }

            //abaixo
            pos.definePosition(position.linha + 1, position.coluna);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha + 1, pos.coluna);
            }

            //direita
            pos.definePosition(position.linha, position.coluna + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha, pos.coluna + 1);
            }


            //esquerda
            pos.definePosition(position.linha, position.coluna - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.definePosition(pos.linha, pos.coluna - 1);
            }
            return mat;
        }
    }
}
