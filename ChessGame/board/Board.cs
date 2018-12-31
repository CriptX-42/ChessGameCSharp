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

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool therePiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if (therePiece(pos))
            {
                throw new BoardException("There is already a task at this position!!!");
            }
                pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos)
        {
            if(pos.line<0 || pos.line >= lines || pos.column < 0 || 
                pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position"); 
            }
        }
    }
}
