namespace MongoDriverTest
{
    partial class FDodajTakmicenje
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
            this.label1 = new System.Windows.Forms.Label();
            this.LvCntryList = new System.Windows.Forms.ListView();
            this.columnReprezentacije = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LvStatistics = new System.Windows.Forms.ListView();
            this.columnDrzava = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.BtnAddRep = new System.Windows.Forms.Button();
            this.BtnAddCntry = new System.Windows.Forms.Button();
            this.RtbOpis = new System.Windows.Forms.RichTextBox();
            this.TbCntryName = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RtbSysIgr = new System.Windows.Forms.RichTextBox();
            this.TbLstWin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TbIme = new System.Windows.Forms.TextBox();
            this.BtnRemRep = new System.Windows.Forms.Button();
            this.BtnRemCntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opis";
            // 
            // LvCntryList
            // 
            this.LvCntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnReprezentacije});
            this.LvCntryList.Location = new System.Drawing.Point(99, 338);
            this.LvCntryList.Name = "LvCntryList";
            this.LvCntryList.Size = new System.Drawing.Size(252, 113);
            this.LvCntryList.TabIndex = 1;
            this.LvCntryList.UseCompatibleStateImageBehavior = false;
            this.LvCntryList.View = System.Windows.Forms.View.Details;
            // 
            // columnReprezentacije
            // 
            this.columnReprezentacije.Text = "Ime Reprezentacije";
            this.columnReprezentacije.Width = 246;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sistem Igranja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spisak Drzava";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Poslednji Pobednik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Statistika";
            // 
            // LvStatistics
            // 
            this.LvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDrzava});
            this.LvStatistics.Location = new System.Drawing.Point(458, 338);
            this.LvStatistics.Name = "LvStatistics";
            this.LvStatistics.Size = new System.Drawing.Size(283, 113);
            this.LvStatistics.TabIndex = 8;
            this.LvStatistics.UseCompatibleStateImageBehavior = false;
            this.LvStatistics.View = System.Windows.Forms.View.Details;
            // 
            // columnDrzava
            // 
            this.columnDrzava.Text = "Ime Drzave i Broj Pobeda";
            this.columnDrzava.Width = 279;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(729, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnAddRep
            // 
            this.BtnAddRep.Location = new System.Drawing.Point(99, 309);
            this.BtnAddRep.Name = "BtnAddRep";
            this.BtnAddRep.Size = new System.Drawing.Size(120, 23);
            this.BtnAddRep.TabIndex = 13;
            this.BtnAddRep.Text = "Dodaj Reprezentaciju";
            this.BtnAddRep.UseVisualStyleBackColor = true;
            this.BtnAddRep.Click += new System.EventHandler(this.BtnAddRep_Click);
            // 
            // BtnAddCntry
            // 
            this.BtnAddCntry.Location = new System.Drawing.Point(458, 309);
            this.BtnAddCntry.Name = "BtnAddCntry";
            this.BtnAddCntry.Size = new System.Drawing.Size(123, 23);
            this.BtnAddCntry.TabIndex = 14;
            this.BtnAddCntry.Text = "Dodaj Drzavu";
            this.BtnAddCntry.UseVisualStyleBackColor = true;
            this.BtnAddCntry.Click += new System.EventHandler(this.BtnAddCntry_Click);
            // 
            // RtbOpis
            // 
            this.RtbOpis.Location = new System.Drawing.Point(99, 88);
            this.RtbOpis.Name = "RtbOpis";
            this.RtbOpis.Size = new System.Drawing.Size(252, 76);
            this.RtbOpis.TabIndex = 16;
            this.RtbOpis.Text = "";
            // 
            // TbCntryName
            // 
            this.TbCntryName.Location = new System.Drawing.Point(458, 156);
            this.TbCntryName.Name = "TbCntryName";
            this.TbCntryName.Size = new System.Drawing.Size(272, 111);
            this.TbCntryName.TabIndex = 18;
            this.TbCntryName.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ime Drzave";
            // 
            // RtbSysIgr
            // 
            this.RtbSysIgr.Location = new System.Drawing.Point(99, 202);
            this.RtbSysIgr.Name = "RtbSysIgr";
            this.RtbSysIgr.Size = new System.Drawing.Size(252, 78);
            this.RtbSysIgr.TabIndex = 21;
            this.RtbSysIgr.Text = "";
            // 
            // TbLstWin
            // 
            this.TbLstWin.Location = new System.Drawing.Point(458, 52);
            this.TbLstWin.Name = "TbLstWin";
            this.TbLstWin.Size = new System.Drawing.Size(272, 20);
            this.TbLstWin.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Ime";
            // 
            // TbIme
            // 
            this.TbIme.Location = new System.Drawing.Point(99, 33);
            this.TbIme.Name = "TbIme";
            this.TbIme.Size = new System.Drawing.Size(252, 20);
            this.TbIme.TabIndex = 24;
            // 
            // BtnRemRep
            // 
            this.BtnRemRep.Location = new System.Drawing.Point(225, 309);
            this.BtnRemRep.Name = "BtnRemRep";
            this.BtnRemRep.Size = new System.Drawing.Size(126, 23);
            this.BtnRemRep.TabIndex = 25;
            this.BtnRemRep.Text = "Izbrisi Reprezentaciju";
            this.BtnRemRep.UseVisualStyleBackColor = true;
            this.BtnRemRep.Click += new System.EventHandler(this.BtnRemRep_Click);
            // 
            // BtnRemCntry
            // 
            this.BtnRemCntry.Location = new System.Drawing.Point(598, 309);
            this.BtnRemCntry.Name = "BtnRemCntry";
            this.BtnRemCntry.Size = new System.Drawing.Size(132, 23);
            this.BtnRemCntry.TabIndex = 26;
            this.BtnRemCntry.Text = "Izbrisi Drzavu";
            this.BtnRemCntry.UseVisualStyleBackColor = true;
            this.BtnRemCntry.Click += new System.EventHandler(this.BtnRemCntry_Click);
            // 
            // FDodajTakmicenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 492);
            this.Controls.Add(this.BtnRemCntry);
            this.Controls.Add(this.BtnRemRep);
            this.Controls.Add(this.TbIme);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TbLstWin);
            this.Controls.Add(this.RtbSysIgr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbCntryName);
            this.Controls.Add(this.RtbOpis);
            this.Controls.Add(this.BtnAddCntry);
            this.Controls.Add(this.BtnAddRep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LvStatistics);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LvCntryList);
            this.Controls.Add(this.label1);
            this.Name = "FDodajTakmicenje";
            this.Text = "FDodajTakmicenje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LvCntryList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnReprezentacije;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView LvStatistics;
        private System.Windows.Forms.ColumnHeader columnDrzava;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnAddRep;
        private System.Windows.Forms.Button BtnAddCntry;
        private System.Windows.Forms.RichTextBox RtbOpis;
        private System.Windows.Forms.RichTextBox TbCntryName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox RtbSysIgr;
        private System.Windows.Forms.TextBox TbLstWin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbIme;
        private System.Windows.Forms.Button BtnRemRep;
        private System.Windows.Forms.Button BtnRemCntry;
    }
}