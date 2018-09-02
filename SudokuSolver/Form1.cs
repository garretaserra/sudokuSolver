using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sudoku_dgv.ColumnCount = 9;
            sudoku_dgv.RowCount = 9;
            Sudoku sudoku =  Sudoku.getSudoku();
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    sudoku.cells[i, j] = new Cell();
                    sudoku.cells[i, j].setPosition(i, j);
                }
            }
        }

        private void solve_btn_Click(object sender, EventArgs e)
        {
            //Set values into memory
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    try
                    {
                        int tmp = Convert.ToInt32(sudoku_dgv.Rows[i].Cells[j].Value);
                        //If value is erased, reset possibilites to all
                        if(tmp==0)
                        {
                            Sudoku.getSudoku().cells[i, j].possible.RemoveAll(x => 1.Equals(1));
                            for(int k = 1; k<10; k++)
                            {
                                Sudoku.getSudoku().cells[i, j].possible.Add(k);
                            }
                        }
                        Sudoku.getSudoku().cells[i, j].value = tmp;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong format");
                    }
                }
            }
            if (!Sudoku.getSudoku().validate())
            {
                MessageBox.Show("Wrong values");
                return;
            }
            for (int n = 0; n < 10; n++)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Sudoku.getSudoku().cells[i, j].check();
                        int val = Sudoku.getSudoku().cells[i, j].value;
                        if (val != 0)
                            sudoku_dgv.Rows[i].Cells[j].Value = val;
                        else
                            sudoku_dgv.Rows[i].Cells[j].Value = "";
                    }
                }
            }
            Sudoku.getSudoku().possible();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int val = Sudoku.getSudoku().cells[i, j].value;
                    if (val != 0)
                        sudoku_dgv.Rows[i].Cells[j].Value = val;
                }
            }
        }

        private void sudoku_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String s = "";
            foreach(int x in Sudoku.getSudoku().cells[e.RowIndex, e.ColumnIndex].possible)
            {
                s += (x + ", ");
            }
            posValues_lbl.Text = s;
        }
    }
}
