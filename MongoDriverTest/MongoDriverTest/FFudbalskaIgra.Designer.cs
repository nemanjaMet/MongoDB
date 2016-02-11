namespace MongoDriverTest
{
    partial class FFudbalskaIgra
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
            this.ScoreBoard = new System.Windows.Forms.Panel();
            this.GostSkracenica = new System.Windows.Forms.Label();
            this.DomacinSkracenica = new System.Windows.Forms.Label();
            this.Minuti = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RezultatGost = new System.Windows.Forms.Label();
            this.RezultatDomacin = new System.Windows.Forms.Label();
            this.RtbDogadjaji = new System.Windows.Forms.RichTextBox();
            this.RtbSastavDomacin = new System.Windows.Forms.RichTextBox();
            this.RtbSastavGost = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ScoreBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScoreBoard.Controls.Add(this.GostSkracenica);
            this.ScoreBoard.Controls.Add(this.DomacinSkracenica);
            this.ScoreBoard.Controls.Add(this.Minuti);
            this.ScoreBoard.Controls.Add(this.label1);
            this.ScoreBoard.Controls.Add(this.RezultatGost);
            this.ScoreBoard.Controls.Add(this.RezultatDomacin);
            this.ScoreBoard.Location = new System.Drawing.Point(252, 13);
            this.ScoreBoard.Margin = new System.Windows.Forms.Padding(4);
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.Size = new System.Drawing.Size(368, 104);
            this.ScoreBoard.TabIndex = 0;
            this.ScoreBoard.Visible = false;
            // 
            // GostSkracenica
            // 
            this.GostSkracenica.AutoSize = true;
            this.GostSkracenica.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GostSkracenica.Location = new System.Drawing.Point(264, 9);
            this.GostSkracenica.Name = "GostSkracenica";
            this.GostSkracenica.Size = new System.Drawing.Size(95, 42);
            this.GostSkracenica.TabIndex = 5;
            this.GostSkracenica.Text = "SRB";
            // 
            // DomacinSkracenica
            // 
            this.DomacinSkracenica.AutoSize = true;
            this.DomacinSkracenica.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomacinSkracenica.Location = new System.Drawing.Point(14, 9);
            this.DomacinSkracenica.Name = "DomacinSkracenica";
            this.DomacinSkracenica.Size = new System.Drawing.Size(95, 42);
            this.DomacinSkracenica.TabIndex = 4;
            this.DomacinSkracenica.Text = "SRB";
            // 
            // Minuti
            // 
            this.Minuti.AutoSize = true;
            this.Minuti.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minuti.Location = new System.Drawing.Point(174, 67);
            this.Minuti.Name = "Minuti";
            this.Minuti.Size = new System.Drawing.Size(42, 37);
            this.Minuti.TabIndex = 3;
            this.Minuti.Text = "0\'";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // RezultatGost
            // 
            this.RezultatGost.AutoSize = true;
            this.RezultatGost.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RezultatGost.Location = new System.Drawing.Point(218, 9);
            this.RezultatGost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RezultatGost.Name = "RezultatGost";
            this.RezultatGost.Size = new System.Drawing.Size(39, 42);
            this.RezultatGost.TabIndex = 1;
            this.RezultatGost.Text = "0";
            // 
            // RezultatDomacin
            // 
            this.RezultatDomacin.AutoSize = true;
            this.RezultatDomacin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RezultatDomacin.Location = new System.Drawing.Point(116, 9);
            this.RezultatDomacin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RezultatDomacin.Name = "RezultatDomacin";
            this.RezultatDomacin.Size = new System.Drawing.Size(39, 42);
            this.RezultatDomacin.TabIndex = 0;
            this.RezultatDomacin.Text = "0";
            // 
            // RtbDogadjaji
            // 
            this.RtbDogadjaji.Enabled = false;
            this.RtbDogadjaji.Location = new System.Drawing.Point(243, 135);
            this.RtbDogadjaji.Name = "RtbDogadjaji";
            this.RtbDogadjaji.ReadOnly = true;
            this.RtbDogadjaji.Size = new System.Drawing.Size(388, 342);
            this.RtbDogadjaji.TabIndex = 1;
            this.RtbDogadjaji.Text = "";
            // 
            // RtbSastavDomacin
            // 
            this.RtbSastavDomacin.Enabled = false;
            this.RtbSastavDomacin.Location = new System.Drawing.Point(12, 135);
            this.RtbSastavDomacin.Name = "RtbSastavDomacin";
            this.RtbSastavDomacin.ReadOnly = true;
            this.RtbSastavDomacin.Size = new System.Drawing.Size(225, 342);
            this.RtbSastavDomacin.TabIndex = 2;
            this.RtbSastavDomacin.Text = "";
            // 
            // RtbSastavGost
            // 
            this.RtbSastavGost.Enabled = false;
            this.RtbSastavGost.Location = new System.Drawing.Point(637, 135);
            this.RtbSastavGost.Name = "RtbSastavGost";
            this.RtbSastavGost.ReadOnly = true;
            this.RtbSastavGost.Size = new System.Drawing.Size(268, 342);
            this.RtbSastavGost.TabIndex = 3;
            this.RtbSastavGost.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Domacin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(753, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gost";
            // 
            // FFudbalskaIgra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RtbSastavGost);
            this.Controls.Add(this.RtbSastavDomacin);
            this.Controls.Add(this.RtbDogadjaji);
            this.Controls.Add(this.ScoreBoard);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FFudbalskaIgra";
            this.Text = "FFudbalskaIgra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FFudbalskaIgra_FormClosing);
            this.Shown += new System.EventHandler(this.BtnSimulacijaUtakmice_Click);
            this.ScoreBoard.ResumeLayout(false);
            this.ScoreBoard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ScoreBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GostSkracenica;
        private System.Windows.Forms.Label DomacinSkracenica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label Minuti;
        public System.Windows.Forms.Label RezultatGost;
        public System.Windows.Forms.Label RezultatDomacin;
        public System.Windows.Forms.RichTextBox RtbDogadjaji;
        public System.Windows.Forms.RichTextBox RtbSastavDomacin;
        public System.Windows.Forms.RichTextBox RtbSastavGost;
    }
}