

namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numberOfMoves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.numberOfMoves = 0;
        }

        public void incNumerOfMoves()
        {
            numberOfMoves++;
        }

        public bool hasPossibleMoves()
        {
            bool[,] mat = possiblesMoves();

            for (int i = 0; i < board.linhas; i++)
            {
                for (int j = 0; j < board.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possiblesMoves()[pos.linha, pos.coluna];
        }
        public abstract bool[,] possiblesMoves();
    }
}
