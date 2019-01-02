using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtdeMovimentos { get; protected set; }
        public Board tab { get; protected set; }     

        public Piece(Board tab ,Color color)
        {
            this.position = null;
            this.tab = tab;
            this.color = color;
            this.qtdeMovimentos = 0;
        }

        // Incremento de movimentos
        public void incrementAmountMoviments()
        {
            qtdeMovimentos++;
        }

        // Matriz de booleano, verdadeiro onde a peça poder, e falso onde não poder
        // Não tem implementação nesse classe
        public abstract bool[,] possibleMovements();
    }
}
