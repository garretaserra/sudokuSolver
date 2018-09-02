using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Sudoku
    {
        public Cell[,] cells = new Cell[9, 9];
        private static Sudoku sudoku = null;

        private Sudoku (){}

        public void setPositions()
        {
            //Set the row and column of each cell
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j].setPosition(i, j);
                }
            }
        }

        public static Sudoku getSudoku()
        {
            if (sudoku == null)
                sudoku = new Sudoku();
            return sudoku;
        }

        public bool validate()
        {
            return validateColumns() && validateRows() && validateQuadrants();
        }
        public bool validateColumns()
        {
            for(int column = 0; column < 9; column++)
            {
                for(int row = 0; row < 9; row++)
                {
                    for (int i = 0; i < 9 && i != row; i++)
                    { 
                        int val = getSudoku().cells[row, column].value;
                        if (val == 0)
                            break;
                        if (val == getSudoku().cells[i, column].value)
                            return false;
                    }
                }
            }
            return true;
        }
        public bool validateRows()
        {
            for (int column = 0; column < 9; column++)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int i = 0; i < 9 && i != column; i++)
                    {
                        int val = getSudoku().cells[row, column].value;
                        if (val == 0)
                            break;
                        if (val == getSudoku().cells[row, i].value)
                            return false;
                    }
                }
            }
            return true;
        }
        public bool validateQuadrants()
        {
            for (int quadrantRow = 0; quadrantRow < 3; quadrantRow++)
            {
                for (int quadrantColumn = 0; quadrantColumn < 3; quadrantColumn++)
                {
                    for(int row = 0; row < 3; row++)
                    {
                        for(int column = 0; column < 3; column++)
                        {
                            for(int x = 0; x < 3; x++)
                            {
                                for(int y = 0; y < 3; y++)
                                {
                                    //Check for same cell
                                    if (x == row && y == column)
                                        continue;
                                    if (getSudoku().cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].value == 0)
                                        break;
                                    //check same value
                                    if(getSudoku().cells[quadrantRow*3+row,quadrantColumn*3+column].value
                                        == getSudoku().cells[quadrantRow*3+x, quadrantColumn*3+y].value)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void possible()
        {
            possColumn();
            possRow();
        }
        public void possColumn()
        {
            for(int column = 0; column < 9; column++)
            {
                List<int> possible = new List<int>();
                //Add all possible elements of column from all cells in one list
                for(int row = 0; row < 9; row++)
                {
                    if (cells[row, column].value != 0)
                        continue;
                    possible.AddRange(cells[row, column].possible);
                }
                //Check if there is only one possibility
                for (int row = 0; row < 9; row++)
                {
                    int val = cells[row, column].value;
                    if (val != 0)
                        continue;
                    foreach (int poss in cells[row, column].possible)
                    {
                        //If there is only one set the value to the unique possibility
                        int count = possible.Where(x => x.Equals(poss)).Count();
                        if(count == 1)
                        {
                            cells[row, column].value = poss;
                            cells[row, column].possible.RemoveAll(x => 1.Equals(1));
                            cells[row, column].possible.Add(poss);
                            break;
                        }
                    }
                }
            }
        }
        public void possRow()
        {
            for (int row = 0; row < 9; row++)
            {
                List<int> possible = new List<int>();
                //Add all possible elements of row from all cells in one list
                for (int column = 0; column < 9; column++)
                {
                    if (cells[row, column].value != 0)
                        continue;
                    possible.AddRange(cells[row, column].possible);
                }
                //Check if there is only one possibility
                for (int column = 0; column < 9; column++)
                {
                    int val = cells[row, column].value;
                    if (val != 0)
                        continue;
                    foreach (int poss in cells[row, column].possible)
                    {
                        //If there is only one set the value to the unique possibility
                        int count = possible.Where(x => x.Equals(poss)).Count();
                        if (count == 1)
                        {
                            cells[row, column].value = poss;
                            cells[row, column].possible.RemoveAll(x => 1.Equals(1));
                            cells[row, column].possible.Add(poss);
                            break;
                        }
                    }
                }
            }
        }
        public void possQuadrant()
        {

        }
    }
}
