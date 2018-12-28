using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        public Piece[,] piece { get; set; }

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            piece = new Piece[lines, columns];
        }
    }
}
