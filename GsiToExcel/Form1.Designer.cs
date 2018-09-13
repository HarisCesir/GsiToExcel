namespace GsiToExcel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonUcitajGSI = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDZaGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeznaTacka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OdstojanjeODLetve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrvaPodjela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugaPodjela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrednjaVisinkaRazlika = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OdakleJeUzeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaVisinskihRazlika = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaDuzina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oznaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonNapraviNO1 = new System.Windows.Forms.Button();
            this.buttonNapraviNO2 = new System.Windows.Forms.Button();
            this.buttonPreracuna = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preračunajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrišiRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUcitajGSI
            // 
            this.buttonUcitajGSI.Location = new System.Drawing.Point(414, 40);
            this.buttonUcitajGSI.Name = "buttonUcitajGSI";
            this.buttonUcitajGSI.Size = new System.Drawing.Size(89, 42);
            this.buttonUcitajGSI.TabIndex = 0;
            this.buttonUcitajGSI.Text = "Učitaj GSI";
            this.buttonUcitajGSI.UseVisualStyleBackColor = true;
            this.buttonUcitajGSI.Click += new System.EventHandler(this.buttonUcitajGSI_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDZaGrid,
            this.VeznaTacka,
            this.OdstojanjeODLetve,
            this.PrvaPodjela,
            this.DrugaPodjela,
            this.Proba,
            this.SrednjaVisinkaRazlika,
            this.ODDO,
            this.OdakleJeUzeta,
            this.SumaVisinskihRazlika,
            this.SumaDuzina,
            this.Oznaka});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(864, 357);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // IDZaGrid
            // 
            this.IDZaGrid.DataPropertyName = "IDZaGrid";
            this.IDZaGrid.HeaderText = "IDZaGrid";
            this.IDZaGrid.Name = "IDZaGrid";
            this.IDZaGrid.Visible = false;
            // 
            // VeznaTacka
            // 
            this.VeznaTacka.DataPropertyName = "VeznaTacka";
            this.VeznaTacka.HeaderText = "Vezna tačka";
            this.VeznaTacka.Name = "VeznaTacka";
            // 
            // OdstojanjeODLetve
            // 
            this.OdstojanjeODLetve.DataPropertyName = "OdstojanjeODLetve";
            this.OdstojanjeODLetve.HeaderText = "Odstojanje od letve";
            this.OdstojanjeODLetve.Name = "OdstojanjeODLetve";
            // 
            // PrvaPodjela
            // 
            this.PrvaPodjela.DataPropertyName = "PrvaPodjela";
            this.PrvaPodjela.HeaderText = "Prva podjela Z1 P1 Z1-P1";
            this.PrvaPodjela.Name = "PrvaPodjela";
            // 
            // DrugaPodjela
            // 
            this.DrugaPodjela.DataPropertyName = "DrugaPodjela";
            this.DrugaPodjela.HeaderText = "Druga podjela Z2 P2 Z2-P2";
            this.DrugaPodjela.Name = "DrugaPodjela";
            // 
            // Proba
            // 
            this.Proba.DataPropertyName = "Proba";
            this.Proba.HeaderText = "Proba";
            this.Proba.Name = "Proba";
            this.Proba.ReadOnly = true;
            // 
            // SrednjaVisinkaRazlika
            // 
            this.SrednjaVisinkaRazlika.DataPropertyName = "SrednjaVisinskaRazlika";
            this.SrednjaVisinkaRazlika.HeaderText = "Srednja visinska razlika";
            this.SrednjaVisinkaRazlika.Name = "SrednjaVisinkaRazlika";
            this.SrednjaVisinkaRazlika.ReadOnly = true;
            // 
            // ODDO
            // 
            this.ODDO.DataPropertyName = "ODDO";
            this.ODDO.HeaderText = "OD-Do";
            this.ODDO.Name = "ODDO";
            this.ODDO.Visible = false;
            // 
            // OdakleJeUzeta
            // 
            this.OdakleJeUzeta.DataPropertyName = "OdakleJeuzeta";
            this.OdakleJeUzeta.HeaderText = "OdakleJeUzeta";
            this.OdakleJeUzeta.Name = "OdakleJeUzeta";
            this.OdakleJeUzeta.Visible = false;
            // 
            // SumaVisinskihRazlika
            // 
            this.SumaVisinskihRazlika.DataPropertyName = "SumaVisinskihRazlika";
            this.SumaVisinskihRazlika.HeaderText = "Suma visinskih razlika";
            this.SumaVisinskihRazlika.Name = "SumaVisinskihRazlika";
            this.SumaVisinskihRazlika.ReadOnly = true;
            // 
            // SumaDuzina
            // 
            this.SumaDuzina.DataPropertyName = "SumaDuzina";
            this.SumaDuzina.HeaderText = "Suma dužina";
            this.SumaDuzina.Name = "SumaDuzina";
            this.SumaDuzina.ReadOnly = true;
            // 
            // Oznaka
            // 
            this.Oznaka.DataPropertyName = "Oznaka";
            this.Oznaka.HeaderText = "Oznaka";
            this.Oznaka.Name = "Oznaka";
            this.Oznaka.Visible = false;
            // 
            // buttonNapraviNO1
            // 
            this.buttonNapraviNO1.Location = new System.Drawing.Point(648, 40);
            this.buttonNapraviNO1.Name = "buttonNapraviNO1";
            this.buttonNapraviNO1.Size = new System.Drawing.Size(92, 42);
            this.buttonNapraviNO1.TabIndex = 4;
            this.buttonNapraviNO1.Text = "Napravi NO1 obrazac";
            this.buttonNapraviNO1.UseVisualStyleBackColor = true;
            this.buttonNapraviNO1.Click += new System.EventHandler(this.buttonNapraviNO1_Click);
            // 
            // buttonNapraviNO2
            // 
            this.buttonNapraviNO2.Location = new System.Drawing.Point(763, 40);
            this.buttonNapraviNO2.Name = "buttonNapraviNO2";
            this.buttonNapraviNO2.Size = new System.Drawing.Size(89, 42);
            this.buttonNapraviNO2.TabIndex = 7;
            this.buttonNapraviNO2.Text = "Napravi NO2 obrazac";
            this.buttonNapraviNO2.UseVisualStyleBackColor = true;
            this.buttonNapraviNO2.Click += new System.EventHandler(this.buttonNapraviNO2_Click);
            // 
            // buttonPreracuna
            // 
            this.buttonPreracuna.Location = new System.Drawing.Point(526, 40);
            this.buttonPreracuna.Name = "buttonPreracuna";
            this.buttonPreracuna.Size = new System.Drawing.Size(100, 42);
            this.buttonPreracuna.TabIndex = 8;
            this.buttonPreracuna.Text = "Preračunaj tabelu";
            this.buttonPreracuna.UseVisualStyleBackColor = true;
            this.buttonPreracuna.Click += new System.EventHandler(this.buttonPreracuna_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preračunajToolStripMenuItem,
            this.obrišiRedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // preračunajToolStripMenuItem
            // 
            this.preračunajToolStripMenuItem.Name = "preračunajToolStripMenuItem";
            this.preračunajToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.preračunajToolStripMenuItem.Text = "Preračunaj";
            this.preračunajToolStripMenuItem.Click += new System.EventHandler(this.preračunajToolStripMenuItem_Click);
            // 
            // obrišiRedToolStripMenuItem
            // 
            this.obrišiRedToolStripMenuItem.Name = "obrišiRedToolStripMenuItem";
            this.obrišiRedToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.obrišiRedToolStripMenuItem.Text = "Obriši red";
            this.obrišiRedToolStripMenuItem.Click += new System.EventHandler(this.obrišiRedToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            this.postavkeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.postavkeToolStripMenuItem.Text = "Postavke";
            this.postavkeToolStripMenuItem.Click += new System.EventHandler(this.postavkeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonPreracuna);
            this.Controls.Add(this.buttonNapraviNO2);
            this.Controls.Add(this.buttonNapraviNO1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonUcitajGSI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GsiToExcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUcitajGSI;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonNapraviNO1;
        private System.Windows.Forms.Button buttonNapraviNO2;
        private System.Windows.Forms.Button buttonPreracuna;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem preračunajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrišiRedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDZaGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeznaTacka;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdstojanjeODLetve;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrvaPodjela;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugaPodjela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proba;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrednjaVisinkaRazlika;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdakleJeUzeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumaVisinskihRazlika;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumaDuzina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oznaka;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
    }
}

