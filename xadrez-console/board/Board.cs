﻿
namespace board
{
    class Board
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Piece[,] pieces;

        public Board (int linas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;

            pieces = new Piece[linhas, colunas];
        }

    }
}
