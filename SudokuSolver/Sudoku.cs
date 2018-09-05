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
        public static Sudoku reset()
        {
            sudoku = new Sudoku();
            for(int row = 0; row<9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    sudoku.cells[row, col] = new Cell();
                }
            }
            return sudoku;
        }
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
        public int signature()
        {
            int count = 0;
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col <9; col++)
                {
                    count += cells[row, col].getvalue() * 1000;
                    foreach(int pos in cells[row, col].possible)
                    {
                        count += pos;
                    }
                }
            }
            return count;
        }

        //Validation if values are consistent with Sudoku rules
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
                        int val = getSudoku().cells[row, column].getvalue();
                        if (val == 0)
                            break;
                        if (val == getSudoku().cells[i, column].getvalue())
                        {
                            return false;
                        }
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
                        int val = getSudoku().cells[row, column].getvalue();
                        if (val == 0)
                            break;
                        if (val == getSudoku().cells[row, i].getvalue())
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
                                    if (getSudoku().cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].getvalue() == 0)
                                        break;
                                    //check same value
                                    if(getSudoku().cells[quadrantRow*3+row,quadrantColumn*3+column].getvalue()
                                        == getSudoku().cells[quadrantRow*3+x, quadrantColumn*3+y].getvalue())
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

        //Check if a unique possible values exist within a set
        public void possible()
        {
            possColumn();
            possRow();
            possQuadrant();
        }
        private void possColumn()
        {
            for(int column = 0; column < 9; column++)
            {
                List<int> possible = new List<int>();
                //Add all possible elements of column from all cells in one list
                for(int row = 0; row < 9; row++)
                {
                    if (cells[row, column].getvalue() != 0)
                        continue;
                    possible.AddRange(cells[row, column].possible);
                }
                //Check if there is only one possibility
                for (int row = 0; row < 9; row++)
                {
                    int val = cells[row, column].getvalue();
                    if (val != 0)
                        continue;
                    foreach (int poss in cells[row, column].possible)
                    {
                        //If there is only one set the value to the unique possibility
                        int count = possible.Where(x => x.Equals(poss)).Count();
                        if(count == 1)
                        {
                            cells[row, column].setvalue(poss);
                            cells[row, column].possible.Clear();
                            cells[row, column].possible.Add(poss);
                            cells[row, column].check();
                            break;
                        }
                    }
                }
            }
        }
        private void possRow()
        {
            for (int row = 0; row < 9; row++)
            {
                List<int> possible = new List<int>();
                //Add all possible elements of row from all cells in one list
                for (int column = 0; column < 9; column++)
                {
                    if (cells[row, column].getvalue() != 0)
                        continue;
                    possible.AddRange(cells[row, column].possible);
                }
                //Check if there is only one possibility
                for (int column = 0; column < 9; column++)
                {
                    int val = cells[row, column].getvalue();
                    if (val != 0)
                        continue;
                    foreach (int poss in cells[row, column].possible)
                    {
                        //If there is only one set the value to the unique possibility
                        int count = possible.Where(x => x.Equals(poss)).Count();
                        if (count == 1)
                        {
                            cells[row, column].setvalue(poss);
                            cells[row, column].possible.Clear();
                            cells[row, column].possible.Add(poss);
                            cells[row, column].check();
                            break;
                        }
                    }
                }
            }
        }
        private void possQuadrant()
        {
            for (int quadrantRow = 0; quadrantRow < 3; quadrantRow++)
            {
                for (int quadrantColumn = 0; quadrantColumn < 3; quadrantColumn++)
                {
                    List<int> possible = new List<int>();
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            possible.AddRange(cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].possible);
                        }
                    }
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            foreach (int pos in cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].possible)
                            {
                                //If there is only one set the value to the unique possibility
                                int count = possible.Where(x => x.Equals(pos)).Count();
                                if (count == 1)
                                {
                                    cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].setvalue(pos);
                                    cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].possible.Clear();
                                    cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].possible.Add(pos);
                                    cells[quadrantRow * 3 + row, quadrantColumn * 3 + column].check();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        //Check if 2 values have to be in 2 cells and remove from possibility in the other cells in set
        private void pos2(List<Cell> cells)
        {
            //Iterate over all 2 number possibilities
            for(int pos1 = 1; pos1 < 10; pos1++)
            {
                for(int pos2 = 1; pos2 < 10; pos2++)
                {
                    //Check if there are 2 cells with only these possibilities
                    int count = 0;
                    foreach(Cell cell in cells.Where(x => x.possible.Count.Equals(2)))
                    {
                        if (cell.possible.Except(new List<int>() { pos1, pos2 }).Count() == 0)
                            count++;
                    }
                    //Check if there are 2 cells
                    if(count == 2)
                    {
                        //Remove posibilities from other cells
                        foreach(Cell cell in cells)
                        {
                            if (cell.possible.Except(new List<int>() { pos1, pos2 }).Count() == 0)
                                continue;
                            else
                            {
                                cell.possible.Remove(pos1);
                                cell.possible.Remove(pos2);
                            }
                        }
                    }
                }
            }
        }

        //Get the cells in a set in the sudoku that are not set final
        public void sets()
        {
            //Check Rows
            for(int row = 0; row < 9; row++)
            {
                List<Cell> list = new List<Cell>();
                for (int col = 0; col < 9; col++)
                {
                    Cell tmp = cells[row, col];
                    if (tmp.getvalue() == 0)
                    {
                        list.Add(tmp);
                    }
                }
                pos2(list);
            }
            //Check Columns
            for(int col = 0; col <9; col++)
            {
                List<Cell> list = new List<Cell>();
                for (int row = 0; row < 9; row++)
                {
                    Cell tmp = cells[row, col];
                    if (tmp.getvalue() == 0)
                    {
                        list.Add(tmp);
                    }
                }
                pos2(list);
            }
            //Check Quadrants
            for(int initrow = 0; initrow < 3; initrow++)
            {
                for(int initcol = 0; initcol < 3; initcol++)
                {
                    List<Cell> list = new List<Cell>();
                    for(int row = 0; row < 3; row++)
                    {
                        for(int col = 0; col < 3; col++)
                        {
                            Cell tmp = cells[initrow * 3 + row, initcol * 3 + col];
                            if(tmp.getvalue() == 0)
                            {
                                list.Add(tmp);
                            }
                        }
                    }
                    pos2(list);
                }
            }
        }

        //Check all cells in the Sudoku
        public void check()
        {
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    cells[row, col].check();
                }
            }
        }
    }
}