using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board tab = new Board(8, 8);

                tab.putPiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.putPiece(new Tower(tab, Color.Black), new Position(1, 3));
                tab.putPiece(new King(tab, Color.Black), new Position(0, 2));
                Tela.printBoard(tab);
                Console.ReadLine();
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            

        }
    }
}
