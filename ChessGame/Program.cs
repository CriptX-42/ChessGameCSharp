using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChessPosition pos = new ChessPosition('c', 7);
            //Console.WriteLine(pos);
            //Console.WriteLine(pos.toPosition());
            //Console.ReadLine();
            try
            {
                ChessMatch round = new ChessMatch();
                while (!round.finished)
                {
                    Console.Clear();
                    Tela.printBoard(round.tab);

                    Console.WriteLine();
                    Console.WriteLine("Type a origin position: ");
                    Position origin = Tela.readChessPosition().toPosition();

                    Console.WriteLine("Type a destiny position: ");
                    Position destiny = Tela.readChessPosition().toPosition();

                    round.executeMoviment(origin, destiny);
                }
                
                
                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }


        }
    }
}
