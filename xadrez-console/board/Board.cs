
namespace board
{
    class Board
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Piece[,] pieces;

        public Board (int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;

            pieces = new Piece[linhas, colunas];
        }

        public Piece piece (int linha, int coluna)
        {
            return pieces[linha, coluna];
        }
        public Piece piece(Position pos)
        {
            return pieces[pos.linha, pos.coluna];
        }

        public bool hasPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void setPiece(Piece piece, Position pos)
        {
            if (hasPiece(pos))
            {
                throw new BoardException("Ops! Já existe uma peça nessa posição!");
            }
            pieces[pos.linha, pos.coluna] = piece;
            piece.position = pos;
        }
        
        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null) {
                return null;
            }
            Piece auxPiece = piece(pos);
            auxPiece.position = null;
            pieces[pos.linha, pos.coluna] = null;

            return auxPiece;
        }
        public bool isValidPosition(Position pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
            
        public void validatePosition(Position pos)
        {
            if (!isValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
