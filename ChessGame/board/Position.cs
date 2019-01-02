 using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int line, int colum)
        {
            this.line = line;
            this.column = colum;
        }
        public override string ToString()
        {
            return line
                + ", "
                + column;
        }
    }
}
