using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        public int round { get; private set; }
        public Color currentPlayer { get; private set; }
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
        //executa os movimentos e ainda coloca mais uma jogada, e testa se a pessa é preta ou branca
        public void makeMoviments(Position origin, Position destiny)
        {
            executeMoviment(origin, destiny);
            round++;
            changePlayer();
        }
        //Testa se a pessa é preta ou branca
        public void changePlayer()
        {
           if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }

        }
        //metodo para validar posição de origem
        public void validateOriginPosition(Position pos)
        {
             if(tab.piece(pos) == null)
            {
                throw new BoardException("Don't exist piece in this position");
            }
             if(currentPlayer != tab.piece(pos).color)
            {
                throw new BoardException("This piece is not yours");
            }
            if (!tab.piece(pos).existPossibleMoviments())
            {
                throw new BoardException("This piece is not yours");

            }
        }
        //metodo para validar posição de destino
        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!tab.piece(origin).canMovieFor(destiny))
            {
                throw new BoardException("Destiny position invalid");
            }
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
