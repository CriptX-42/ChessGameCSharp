using System;
using System.Collections.Generic;
using System.Text;
using board;
using Chess;

namespace ChessGame
{
    class Tela
    {
        public static void printBoard(Board tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.columns; j++)
                {
                    if(tab.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else{
                        Tela.printPiece(tab.piece(i, j));
                        Console.Write(" ");
                    }
                }
                
                Console.WriteLine();
            }
            Console.Write("+ A B C D E F G H");
        } 
        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void printPiece(Piece piece)
        {
              if(piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
