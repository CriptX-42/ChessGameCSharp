using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            tab.putPiece(new Tower(tab, Color.Black), new Position(0, 0));
            tab.putPiece(new Tower(tab, Color.Black), new Position(1, 3));
            tab.putPiece(new King(tab, Color.Black), new Position(2, 4));
            Tela.printBoard(tab);
            Console.ReadLine();

        }
    }
}
