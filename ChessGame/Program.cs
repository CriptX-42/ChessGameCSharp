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
                    try
                    {

                    
                    Console.Clear();
                    Tela.printBoard(round.tab);
                    Console.WriteLine();
                    Console.WriteLine("Round: " + round.round);
                    Console.WriteLine("Waiting the player: " + round.currentPlayer);
                    Console.WriteLine();
                    Console.WriteLine("Type a origin position: ");
                    Position origin = Tela.readChessPosition().toPosition();
                    round.validateOriginPosition(origin);

                    bool[,] possiblePositions = round.tab.piece(origin).possibleMovements();

                    Console.Clear();
                    Tela.printBoard(round.tab, possiblePositions);


                    Console.WriteLine();
                    Console.WriteLine("Type a destiny position: ");
                    Position destiny = Tela.readChessPosition().toPosition();
                        round.validateDestinyPosition(origin, destiny);

                    round.makeMoviments(origin, destiny);

                    }catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
