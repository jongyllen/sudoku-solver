using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solver
    {
        static int SIZE = 9;
        private Board board = new Board();

        public Solver(String puzzle)
        {
            board.ReadBoard(puzzle);   
        }

        public Solver(Board board)
        {
            this.board = board;
        }

        public bool Solve()
        {
            return FindSolution(board, 0);
        }

        private bool FindSolution(Board board, int index) 
        {
            int row = index/SIZE, column = index%SIZE;

            if (index == SIZE*SIZE) return true;
            
            if (board.IsFilled(row, column))  return FindSolution(board, index+1);

            foreach(int value in board.GetOptionsForCell(row, column))
            {
                board.SetCellValue(row, column, value);
                if (FindSolution(board, index+1)) return true;
            }
            board.ClearCell(row, column);

            return false;
        }

        public override string ToString()
        {
            return board.ToString();
        }
    }
}
