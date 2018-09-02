namespace SudokuSolver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sudoku_dgv = new System.Windows.Forms.DataGridView();
            this.solve_btn = new System.Windows.Forms.Button();
            this.posValues_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sudoku_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // sudoku_dgv
            // 
            this.sudoku_dgv.AllowDrop = true;
            this.sudoku_dgv.AllowUserToAddRows = false;
            this.sudoku_dgv.AllowUserToDeleteRows = false;
            this.sudoku_dgv.AllowUserToResizeColumns = false;
            this.sudoku_dgv.AllowUserToResizeRows = false;
            this.sudoku_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sudoku_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sudoku_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sudoku_dgv.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sudoku_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.sudoku_dgv.EnableHeadersVisualStyles = false;
            this.sudoku_dgv.Location = new System.Drawing.Point(12, 12);
            this.sudoku_dgv.MultiSelect = false;
            this.sudoku_dgv.Name = "sudoku_dgv";
            this.sudoku_dgv.RowHeadersVisible = false;
            this.sudoku_dgv.RowTemplate.Height = 50;
            this.sudoku_dgv.Size = new System.Drawing.Size(450, 450);
            this.sudoku_dgv.TabIndex = 0;
            this.sudoku_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sudoku_dgv_CellClick);
            // 
            // solve_btn
            // 
            this.solve_btn.Location = new System.Drawing.Point(622, 101);
            this.solve_btn.Name = "solve_btn";
            this.solve_btn.Size = new System.Drawing.Size(75, 23);
            this.solve_btn.TabIndex = 1;
            this.solve_btn.Text = "Solve";
            this.solve_btn.UseVisualStyleBackColor = true;
            this.solve_btn.Click += new System.EventHandler(this.solve_btn_Click);
            // 
            // posValues_lbl
            // 
            this.posValues_lbl.AutoSize = true;
            this.posValues_lbl.Location = new System.Drawing.Point(543, 195);
            this.posValues_lbl.Name = "posValues_lbl";
            this.posValues_lbl.Size = new System.Drawing.Size(81, 13);
            this.posValues_lbl.TabIndex = 2;
            this.posValues_lbl.Text = "Possible Values";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 504);
            this.Controls.Add(this.posValues_lbl);
            this.Controls.Add(this.solve_btn);
            this.Controls.Add(this.sudoku_dgv);
            this.Name = "Form1";
            this.Text = "Sudoku Solver";
            ((System.ComponentModel.ISupportInitialize)(this.sudoku_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView sudoku_dgv;
        private System.Windows.Forms.Button solve_btn;
        private System.Windows.Forms.Label posValues_lbl;
    }
}

