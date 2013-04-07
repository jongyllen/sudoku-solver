using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Board
    {
        static int SIZE = 9;
        private int?[,] board = new int?[SIZE, SIZE];

        public bool IsFilled(int row, int column)
        {
            return board[row,column] != null;
        }


        public void ReadBoard(string boardAsString)
        {
            int index = 0;

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    char c = boardAsString[index++];
                    board[row, col] = ReadValue(c);
                }
            }
        }

        private int? ReadValue(char c)
        {
            return c != '.' ? (int?)char.GetNumericValue(c) : null;
        }

        public List<int?> GetOptionsForCell(int row, int column)
        {
            List<int?> options = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Parallel.For(0, SIZE-1, c => { options.Remove(board[row, c]); });
            //Parallel.For(0, SIZE, r => { options.Remove(board[r, column]); });

            RemoveOptionsInRow(options, row);
            RemoveOptionsInColumn(options, column);
            RemoveOptionsInBox(options, row, column);

            return options;
        }

        private void RemoveOptionsInBox(List<int?> options, int row, int column)
        {
            int boxRow = row - row % 3, boxColumn = column - column % 3;

            for (int rowOffset = 0; rowOffset < 3; rowOffset++)
            {
                for (int columnOffset = 0; columnOffset < 3; columnOffset++)
                {
                    options.Remove(board[boxRow + rowOffset,boxColumn + columnOffset]);
                }
            }
        }

        private void RemoveOptionsInColumn(List<int?> options, int column)
        {
            //Parallel.For(0, SIZE, row =>
            //{
            //    options.Remove(board[row, column]);
            //});

            for (int row = 0; row < SIZE; row++)
            {
                options.Remove(board[row, column]);
            }

        }

        private void RemoveOptionsInRow(List<int?> options, int row)
        {
            //Parallel.For(0, SIZE, column =>
            //{
            //    options.Remove(board[row, column]);
            //});

            for (int column = 0; column < SIZE; column++)
            {
                options.Remove(board[row, column]);
            }
        }

        public void SetCellValue(int row, int column, int value)
        {
            board[row,column] = value;
        }

        public void ClearCell(int row, int column)
        {
            board[row, column] = null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    result.Append(board[row,col] != null ? board[row,col].ToString() : ".");
                    
                    if (col == 2 || col == 5)
                        result.Append("|");
                }
                result.Append("\n");

                if (row == 2 || row == 5)
                    result.Append("---+---+---\n");
            }

            return result.ToString();
        }
    }
}
