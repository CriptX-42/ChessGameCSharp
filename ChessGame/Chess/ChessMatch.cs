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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool xeque { get; private set; }

        public ChessMatch ()
        {
            tab = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            xeque = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
            finished = false;
        }

        public Piece executeMoviment(Position origin, Position destiny)
        {
            Piece p = tab.removePiece(origin);
            p.incrementAmountMoviments();
            Piece capturedPiece = tab.removePiece(destiny);
            tab.putPiece(p, destiny);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        //executa os movimentos e ainda coloca mais uma jogada, e testa se a pessa é preta ou branca
        public void makeMoviments(Position origin, Position destiny)
        {
            Piece captureadPiece = executeMoviment(origin, destiny);
            if (estaEmXeque(currentPlayer))
            {
                desfazMovimento(origin, destiny, captureadPiece);
                throw new BoardException("⚠⚠ Você não pode se colocar em cheque ⚠⚠");
            }
            if (estaEmXeque(adversaria(currentPlayer)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            round++;
            changePlayer();
        }
        public void desfazMovimento(Position origin, Position destiny, Piece captureadPiece)
        {
            Piece p = tab.removePiece(destiny);
            p.decrementAmountMoviments();
            if(captureadPiece != null)
            {
                tab.putPiece(captureadPiece, destiny);
                captured.Remove(captureadPiece);
            }
            tab.putPiece(p, origin);
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
        
        public HashSet<Piece> capturedPieces (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void colocarNovaPeca (char column, int line, Piece piece)
        {
            tab.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces() // aux method
        {
            colocarNovaPeca('c', 1, new Tower(tab, Color.White));
            colocarNovaPeca('c', 2, new Tower(tab, Color.White));
            colocarNovaPeca('d', 2, new Tower(tab, Color.White));
            colocarNovaPeca('e', 2, new Tower(tab, Color.White));
            colocarNovaPeca('e', 1, new Tower(tab, Color.White));
            colocarNovaPeca('d', 1, new King(tab, Color.White));

            colocarNovaPeca('c', 7, new Tower(tab, Color.Black));
            colocarNovaPeca('c', 8, new Tower(tab, Color.Black));
            colocarNovaPeca('d', 7, new Tower(tab, Color.Black));
            colocarNovaPeca('e', 7, new Tower(tab, Color.Black));
            colocarNovaPeca('e', 8, new Tower(tab, Color.Black));
            colocarNovaPeca('d', 8, new King(tab, Color.Black));
            
            
        }
        private Color adversaria(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece king (Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King) // Pra eu testar se uma super classe (Peça) é uma instancia de uma subclasse (Rei) eu uso o "is"
                {
                    return x;
                }
            }
            return null;
        }
        public bool estaEmXeque(Color color)
        {
            Piece K = king(color);
            if(K == null)
            {
                throw new BoardException("⚠ Não existe rei da cor " + color + " no tabuleiro! ⚠");
            }
            foreach (Piece x in piecesInGame(adversaria(color)))
            {
                bool[,] mat = x.possibleMovements();
                if(mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
