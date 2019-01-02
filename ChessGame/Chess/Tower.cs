using board;

namespace Chess
{
    class Tower : Piece
    {
        public Tower(Board tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "T";
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
            Position pos = new Position(0, 0); //(???)

            // --- COMPASS --- //
            // N
            pos.setValues(pos.line - 1, pos.column);
            while (tab.validPosition(pos) && canMove(pos)){
                mat[pos.line, pos.column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            // S
            pos.setValues(pos.line + 1, pos.column);
            while (tab.validPosition(pos) && canMove(pos)) {
                mat[pos.line, pos.column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            // E
            pos.setValues(pos.line, pos.column + 1);
            while (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // O
            pos.setValues(pos.line, pos.column - 1);
            while (tab.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (tab.piece(pos) != null || tab.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            // --- COMPASS --- //
            return mat;
        }
    }
}
