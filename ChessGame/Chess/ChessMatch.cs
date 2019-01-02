using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        private int round;
        private Color currentPlayer;
        public bool finished { get; private set; }
        
        public ChessMatch ()
        {
            tab = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            putPieces();
            finished = false;
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = tab.removePiece(origin);
            p.incrementAmountMoviments();
            Piece capturedPiece = tab.removePiece(destiny);
            tab.putPiece(p, destiny);
        }
        private void putPieces() // aux method
        {
            tab.putPiece(new Tower(tab, Color.White), new ChessPosition('c', 1).toPosition());
            tab.putPiece(new Tower(tab, Color.White), new ChessPosition('c', 2).toPosition());
            tab.putPiece(new Tower(tab, Color.White), new ChessPosition('d', 2).toPosition());
            tab.putPiece(new Tower(tab, Color.White), new ChessPosition('e', 2).toPosition());
            tab.putPiece(new Tower(tab, Color.White), new ChessPosition('e', 1).toPosition());
            tab.putPiece(new King(tab, Color.White), new ChessPosition('d', 1).toPosition());

            tab.putPiece(new Tower(tab, Color.Black), new ChessPosition('c', 7).toPosition());
            tab.putPiece(new Tower(tab, Color.Black), new ChessPosition('c', 8).toPosition());
            tab.putPiece(new Tower(tab, Color.Black), new ChessPosition('d', 7).toPosition());
            tab.putPiece(new Tower(tab, Color.Black), new ChessPosition('e', 7).toPosition());
            tab.putPiece(new Tower(tab, Color.Black), new ChessPosition('e', 8).toPosition());
            tab.putPiece(new King(tab, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
