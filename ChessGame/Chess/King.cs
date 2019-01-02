using board;

namespace Chess
{
    class King : Piece
    {
        public King(Board tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        /// <summary>
        /// Verifica se a peça pode mover (se não tem nenhuma adversaria nem nada do genero)
        /// Metodo auxiliar
        /// </summary>
        /// <returns></returns>
        private bool canMove(Position pos)
        {
            Piece p = tab.piece(pos);
            return p == null || p.color != this.color;
        }


        
        /// <summary>
        /// Escrevendo o metodo da superclasse
        /// Sobreposição de métodos
        /// Diz os movimentos que pode ser feito pra classe (no meu caso com base em uma bussola)
        /// </summary>
        /// <returns></returns>
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];
            Position pos = new Position(0, 0);

            
            // --- COMPASS --- //
            // ACIMA
            // N
            pos.setValues(position.line - 1, pos.column);
            if(tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //NE
            pos.setValues(position.line - 1, pos.column + 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //NO
            pos.setValues(position.line - 1, pos.column - 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // -- //ACIMA

            // DOS LADOS
            //O
            pos.setValues(position.line, pos.column - 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //E
            pos.setValues(position.line, pos.column + 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // -- // DOS LADOS

            // ABAIXO
            //S
            pos.setValues(position.line + 1, pos.column);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //SE
            pos.setValues(position.line + 1, pos.column + 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // SO
            pos.setValues(position.line + 1, pos.column - 1);
            if (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // -- // ABAIXO
            // --- COMPASS --- //

            return mat;
        }
    }
}
