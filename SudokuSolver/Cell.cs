using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Cell
    {
        public List<int> possible = new List<int>();
        public int row;
        public int column;
        public int value = 0;

        public Cell()
        {
            for(int i = 1; i < 10; i++)
            {
                possible.Add(i);
            }
        }

        public void setPosition(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public void validate()
        {
            if(possible.Count == 1 && value == 0)
            {
                value = possible[0];
            }
        }

        public void check()
        {
            validate();
            if (value == 0)
                return;
            checkRow();
            checkColumn();
            checkQuadrant();

        }

        private void checkRow()
        {
            for(int x = 0; x < 9; x++)
            {
                if (x == column)
                    continue;
                Sudoku.getSudoku().cells[row, x].possible.Remove(value);
            }
        }

        private void checkColumn()
        {
            for (int x = 0; x < 9; x++)
            {
                if (x == row)
                    continue;
                Sudoku.getSudoku().cells[x, column].possible.Remove(value);
            }
        }

        private void checkQuadrant()
        {
            int initialx = (row / 3) * 3;
            int initialy = (column / 3) * 3;
            for(int x = initialx; x < initialx+3; x++)
            {
                for(int y = initialy; y < initialy+3; y++)
                {
                    if (x == row && y == column)
                        continue;
                    int val = Sudoku.getSudoku().cells[x, y].value;
                    if (val != 0)
                        continue;
                    Sudoku.getSudoku().cells[x, y].possible.Remove(value);
                }
            }
        }
    }
}
