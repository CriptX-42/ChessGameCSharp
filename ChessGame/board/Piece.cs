using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtdeMovimentos { get; protected set; }
        public Board tab { get; protected set; }     

        public Piece(Position position, Board tab ,Color color)
        {
            this.position = position;
            this.tab = tab;
            this.color = color;
            this.qtdeMovimentos = 0;
        }
    }
}
