using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        public Piece[,] pieces { get; set; }

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }
        public Piece piece(int line, int columns)
        {
            return pieces[line, columns];
        }
    }
}
