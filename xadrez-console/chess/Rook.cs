using board;
namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
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

            //acima
            pos.definePosition(position.linha - 1, position.coluna);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
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
                pos.linha++;
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
                pos.coluna++;
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
                pos.coluna = pos.coluna - 1;
            }


            return mat;
        }
    }
}
