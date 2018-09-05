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
            //Initialize cells
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
                            Sudoku.getSudoku().cells[i, j].possible = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                            continue;
                        }
                        if(tmp<0 || tmp>9)
                        {
                            throw new Exception();
                        }
                        Sudoku.getSudoku().cells[i, j].value = tmp;
                        sudoku_dgv.Rows[i].Cells[j].Style.BackColor = Color.DarkGray;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong format: " + sudoku_dgv.Rows[i].Cells[j].Value);
                        sudoku_dgv.Rows[i].Cells[j].Value = null;
                        return;
                    }
                }
            }
            //Check if the numbers inputed are correct
            if (!Sudoku.getSudoku().validate())
            {
                MessageBox.Show("Wrong values");
                return;
            }
            solve(0);
            drawSudoku();
            updateProgressBar();
        }

        private void solve(int sig)
        {
            int signature = Sudoku.getSudoku().signature();
            int newSignature = 10;
            while(signature != newSignature)
            {
                signature = Sudoku.getSudoku().signature();
                Sudoku.getSudoku().check();
                newSignature = Sudoku.getSudoku().signature();
            }
            if (newSignature == sig)
                return;
            signature = 0;
            while(signature != newSignature)
            {
                signature = Sudoku.getSudoku().signature();
                Sudoku.getSudoku().possible();
                newSignature = Sudoku.getSudoku().signature();
            }
            solve(newSignature);
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

        void drawSudoku()
        {
            Sudoku s = Sudoku.getSudoku();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int val = s.cells[i, j].value;
                    if (val != 0)
                        sudoku_dgv.Rows[i].Cells[j].Value = val;
                    else
                        sudoku_dgv.Rows[i].Cells[j].Value = null;
                }
            }
        }

        void updateProgressBar()
        {
            int filledCells = 0;
            Sudoku sudoku = Sudoku.getSudoku();
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    if (sudoku.cells[row, col].value != 0)
                        filledCells++;
                }
            }
            progress_pb.Value = (filledCells * 100) / 81;
        }

        private void reset_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Sudoku.reset();
            drawSudoku();
        }

        private void reset_pos_btn_MouseClick(object sender, MouseEventArgs e)
        {
            for(int row = 0; row<9; row++)
            {
                for(int col = 0; col <9; col++)
                {
                    Sudoku.getSudoku().cells[row, col].possible = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }
            }
        }
    }
}
