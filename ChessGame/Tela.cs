using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessGame
{
    class Tela
    {
        public static void printBoard(Board tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                for (int j = 0; j < tab.columns; j++)
                {
                    if(tab.piece(i, j) == null)
                    {
                        Console.WriteLine("- ");
                    }
                    else{
                        Console.WriteLine(tab.piece(i, j) + " ");
                    }
                }
            }
        }
    }
}
