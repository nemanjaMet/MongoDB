namespace MongoDriverTest
{
    partial class FIzborReprezentacijaZaUtakmicu
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
            this.LvDomacin = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LvGost = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnDomacin = new System.Windows.Forms.Button();
            this.BtnGost = new System.Windows.Forms.Button();
            this.TbDomacin = new System.Windows.Forms.TextBox();
            this.TbGost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnStartGame = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvDomacin
            // 
            this.LvDomacin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LvDomacin.FullRowSelect = true;
            this.LvDomacin.GridLines = true;
            this.LvDomacin.Location = new System.Drawing.Point(12, 39);
            this.LvDomacin.Margin = new System.Windows.Forms.Padding(4);
            this.LvDomacin.MultiSelect = false;
            this.LvDomacin.Name = "LvDomacin";
            this.LvDomacin.Size = new System.Drawing.Size(235, 290);
            this.LvDomacin.TabIndex = 0;
            this.LvDomacin.UseCompatibleStateImageBehavior = false;
            this.LvDomacin.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Reprezentacija";
            this.columnHeader1.Width = 219;
            // 
            // LvGost
            // 
            this.LvGost.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.LvGost.FullRowSelect = true;
            this.LvGost.GridLines = true;
            this.LvGost.Location = new System.Drawing.Point(334, 39);
            this.LvGost.Margin = new System.Windows.Forms.Padding(4);
            this.LvGost.MultiSelect = false;
            this.LvGost.Name = "LvGost";
            this.LvGost.Size = new System.Drawing.Size(258, 290);
            this.LvGost.TabIndex = 1;
            this.LvGost.UseCompatibleStateImageBehavior = false;
            this.LvGost.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Reprezentacija";
            this.columnHeader2.Width = 242;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Domacin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gost";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnStartGame);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TbGost);
            this.panel1.Controls.Add(this.TbDomacin);
            this.panel1.Controls.Add(this.BtnGost);
            this.panel1.Controls.Add(this.BtnDomacin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LvDomacin);
            this.panel1.Controls.Add(this.LvGost);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 495);
            this.panel1.TabIndex = 4;
            // 
            // BtnDomacin
            // 
            this.BtnDomacin.Location = new System.Drawing.Point(11, 336);
            this.BtnDomacin.Name = "BtnDomacin";
            this.BtnDomacin.Size = new System.Drawing.Size(235, 30);
            this.BtnDomacin.TabIndex = 4;
            this.BtnDomacin.Text = "Dodaj domacina";
            this.BtnDomacin.UseVisualStyleBackColor = true;
            this.BtnDomacin.Click += new System.EventHandler(this.BtnDomacin_Click);
            // 
            // BtnGost
            // 
            this.BtnGost.Location = new System.Drawing.Point(334, 336);
            this.BtnGost.Name = "BtnGost";
            this.BtnGost.Size = new System.Drawing.Size(258, 30);
            this.BtnGost.TabIndex = 5;
            this.BtnGost.Text = "Dodaj gosta";
            this.BtnGost.UseVisualStyleBackColor = true;
            this.BtnGost.Click += new System.EventHandler(this.BtnGost_Click);
            // 
            // TbDomacin
            // 
            this.TbDomacin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDomacin.Location = new System.Drawing.Point(12, 399);
            this.TbDomacin.Name = "TbDomacin";
            this.TbDomacin.ReadOnly = true;
            this.TbDomacin.Size = new System.Drawing.Size(235, 26);
            this.TbDomacin.TabIndex = 6;
            this.TbDomacin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TbGost
            // 
            this.TbGost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbGost.Location = new System.Drawing.Point(334, 399);
            this.TbGost.Name = "TbGost";
            this.TbGost.ReadOnly = true;
            this.TbGost.Size = new System.Drawing.Size(258, 26);
            this.TbGost.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "VS";
            // 
            // BtnStartGame
            // 
            this.BtnStartGame.Location = new System.Drawing.Point(206, 450);
            this.BtnStartGame.Name = "BtnStartGame";
            this.BtnStartGame.Size = new System.Drawing.Size(162, 26);
            this.BtnStartGame.TabIndex = 9;
            this.BtnStartGame.Text = "Pokreni utakmicu";
            this.BtnStartGame.UseVisualStyleBackColor = true;
            this.BtnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // FIzborReprezentacijaZaUtakmicu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 489);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FIzborReprezentacijaZaUtakmicu";
            this.Text = "FIzborReprezentacijaZaUtakmicu";
            this.Load += new System.EventHandler(this.FIzborReprezentacijaZaUtakmicu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvDomacin;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView LvGost;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbGost;
        private System.Windows.Forms.TextBox TbDomacin;
        private System.Windows.Forms.Button BtnGost;
        private System.Windows.Forms.Button BtnDomacin;
        private System.Windows.Forms.Button BtnStartGame;
    }
}