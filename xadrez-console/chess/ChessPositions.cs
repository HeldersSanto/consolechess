﻿using System;
using board;

namespace chess
{
    class ChessPositions
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public ChessPositions(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        public Position toPosition()
        {
            return new Position(8 - linha, coluna - 'a');
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
