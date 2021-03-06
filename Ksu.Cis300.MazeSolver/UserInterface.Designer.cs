﻿namespace Ksu.Cis300.MazeSolver
{
    partial class UserInterface
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
            this.uxNew = new System.Windows.Forms.Button();
            this.uxMaze = new Ksu.Cis300.MazeLibrary.Maze();
            this.SuspendLayout();
            // 
            // uxNew
            // 
            this.uxNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNew.Location = new System.Drawing.Point(444, 762);
            this.uxNew.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.uxNew.Name = "uxNew";
            this.uxNew.Size = new System.Drawing.Size(260, 63);
            this.uxNew.TabIndex = 5;
            this.uxNew.Text = "New Maze";
            this.uxNew.UseVisualStyleBackColor = true;
            this.uxNew.Click += new System.EventHandler(this.uxNew_Click);
            // 
            // uxMaze
            // 
            this.uxMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMaze.Location = new System.Drawing.Point(24, 23);
            this.uxMaze.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.uxMaze.Name = "uxMaze";
            this.uxMaze.PathColor = System.Drawing.SystemColors.Highlight;
            this.uxMaze.Size = new System.Drawing.Size(1100, 727);
            this.uxMaze.TabIndex = 4;
            this.uxMaze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uxMaze_MouseClick);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 848);
            this.Controls.Add(this.uxNew);
            this.Controls.Add(this.uxMaze);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "UserInterface";
            this.Text = "Maze Solver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxNew;
        private MazeLibrary.Maze uxMaze;
    }
}

