using board;
namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //no
            pos.definePosition(position.linha - 1, position.coluna - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //so
            pos.definePosition(position.linha + 1, position.coluna + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //se
            pos.definePosition(position.linha + 1, position.coluna - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
    }
}
