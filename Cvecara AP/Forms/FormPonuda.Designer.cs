namespace Cvecara_AP.Forms
{
    partial class FormPonuda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNaslov = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblBoja = new System.Windows.Forms.Label();
            this.txtBoja = new System.Windows.Forms.TextBox();
            this.lblCenaOd = new System.Windows.Forms.Label();
            this.nudCenaOd = new System.Windows.Forms.NumericUpDown();
            this.lblCenaDo = new System.Windows.Forms.Label();
            this.nudCenaDo = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.btnPrikaziSve = new System.Windows.Forms.Button();
            this.dgvPonuda = new System.Windows.Forms.DataGridView();
            this.lblKolicina = new System.Windows.Forms.Label();
            this.nudKolicina = new System.Windows.Forms.NumericUpDown();
            this.btnDodajUKorpu = new System.Windows.Forms.Button();
            this.lblKorpa = new System.Windows.Forms.Label();
            this.dgvKorpa = new System.Windows.Forms.DataGridView();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.btnKupi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenaOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenaDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPonuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorpa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.ForeColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.lblNaslov.Location = new System.Drawing.Point(20, 15);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "Ponuda cveća";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(20, 70);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(20, 92);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(170, 22);
            this.txtNaziv.TabIndex = 2;
            // 
            // lblBoja
            // 
            this.lblBoja.AutoSize = true;
            this.lblBoja.Location = new System.Drawing.Point(205, 70);
            this.lblBoja.Name = "lblBoja";
            this.lblBoja.TabIndex = 3;
            this.lblBoja.Text = "Boja";
            // 
            // txtBoja
            // 
            this.txtBoja.Location = new System.Drawing.Point(205, 92);
            this.txtBoja.Name = "txtBoja";
            this.txtBoja.Size = new System.Drawing.Size(130, 22);
            this.txtBoja.TabIndex = 4;
            // 
            // lblCenaOd
            // 
            this.lblCenaOd.AutoSize = true;
            this.lblCenaOd.Location = new System.Drawing.Point(350, 70);
            this.lblCenaOd.Name = "lblCenaOd";
            this.lblCenaOd.TabIndex = 5;
            this.lblCenaOd.Text = "Cena od";
            // 
            // nudCenaOd
            // 
            this.nudCenaOd.Location = new System.Drawing.Point(350, 92);
            this.nudCenaOd.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudCenaOd.Name = "nudCenaOd";
            this.nudCenaOd.Size = new System.Drawing.Size(100, 22);
            this.nudCenaOd.TabIndex = 6;
            // 
            // lblCenaDo
            // 
            this.lblCenaDo.AutoSize = true;
            this.lblCenaDo.Location = new System.Drawing.Point(465, 70);
            this.lblCenaDo.Name = "lblCenaDo";
            this.lblCenaDo.TabIndex = 7;
            this.lblCenaDo.Text = "Cena do";
            // 
            // nudCenaDo
            // 
            this.nudCenaDo.Location = new System.Drawing.Point(465, 92);
            this.nudCenaDo.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudCenaDo.Name = "nudCenaDo";
            this.nudCenaDo.Size = new System.Drawing.Size(100, 22);
            this.nudCenaDo.TabIndex = 8;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(580, 70);
            this.lblTip.Name = "lblTip";
            this.lblTip.TabIndex = 9;
            this.lblTip.Text = "Tip cveća";
            // 
            // cmbTip
            // 
            this.cmbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTip.Location = new System.Drawing.Point(580, 91);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(190, 24);
            this.cmbTip.TabIndex = 10;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnPretrazi.FlatAppearance.BorderSize = 0;
            this.btnPretrazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPretrazi.ForeColor = System.Drawing.Color.White;
            this.btnPretrazi.Location = new System.Drawing.Point(790, 85);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(100, 36);
            this.btnPretrazi.TabIndex = 11;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // btnPrikaziSve
            // 
            this.btnPrikaziSve.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnPrikaziSve.FlatAppearance.BorderSize = 0;
            this.btnPrikaziSve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikaziSve.ForeColor = System.Drawing.Color.White;
            this.btnPrikaziSve.Location = new System.Drawing.Point(900, 85);
            this.btnPrikaziSve.Name = "btnPrikaziSve";
            this.btnPrikaziSve.Size = new System.Drawing.Size(100, 36);
            this.btnPrikaziSve.TabIndex = 12;
            this.btnPrikaziSve.Text = "Poništi";
            this.btnPrikaziSve.UseVisualStyleBackColor = false;
            // 
            // dgvPonuda
            // 
            this.dgvPonuda.AllowUserToAddRows = false;
            this.dgvPonuda.AllowUserToDeleteRows = false;
            this.dgvPonuda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPonuda.BackgroundColor = System.Drawing.Color.White;
            this.dgvPonuda.Location = new System.Drawing.Point(20, 140);
            this.dgvPonuda.MultiSelect = false;
            this.dgvPonuda.Name = "dgvPonuda";
            this.dgvPonuda.ReadOnly = true;
            this.dgvPonuda.RowHeadersVisible = false;
            this.dgvPonuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPonuda.Size = new System.Drawing.Size(980, 220);
            this.dgvPonuda.TabIndex = 13;
            // 
            // lblKolicina
            // 
            this.lblKolicina.AutoSize = true;
            this.lblKolicina.Location = new System.Drawing.Point(20, 378);
            this.lblKolicina.Name = "lblKolicina";
            this.lblKolicina.TabIndex = 14;
            this.lblKolicina.Text = "Količina";
            // 
            // nudKolicina
            // 
            this.nudKolicina.Location = new System.Drawing.Point(90, 375);
            this.nudKolicina.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudKolicina.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudKolicina.Name = "nudKolicina";
            this.nudKolicina.Size = new System.Drawing.Size(80, 22);
            this.nudKolicina.TabIndex = 15;
            this.nudKolicina.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnDodajUKorpu
            // 
            this.btnDodajUKorpu.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnDodajUKorpu.FlatAppearance.BorderSize = 0;
            this.btnDodajUKorpu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajUKorpu.ForeColor = System.Drawing.Color.White;
            this.btnDodajUKorpu.Location = new System.Drawing.Point(190, 368);
            this.btnDodajUKorpu.Name = "btnDodajUKorpu";
            this.btnDodajUKorpu.Size = new System.Drawing.Size(170, 36);
            this.btnDodajUKorpu.TabIndex = 16;
            this.btnDodajUKorpu.Text = "Dodaj u korpu";
            this.btnDodajUKorpu.UseVisualStyleBackColor = false;
            // 
            // lblKorpa
            // 
            this.lblKorpa.AutoSize = true;
            this.lblKorpa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKorpa.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblKorpa.Location = new System.Drawing.Point(20, 418);
            this.lblKorpa.Name = "lblKorpa";
            this.lblKorpa.TabIndex = 17;
            this.lblKorpa.Text = "Moja korpa";
            // 
            // dgvKorpa
            // 
            this.dgvKorpa.AllowUserToAddRows = false;
            this.dgvKorpa.AllowUserToDeleteRows = false;
            this.dgvKorpa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKorpa.BackgroundColor = System.Drawing.Color.White;
            this.dgvKorpa.Location = new System.Drawing.Point(20, 448);
            this.dgvKorpa.MultiSelect = false;
            this.dgvKorpa.Name = "dgvKorpa";
            this.dgvKorpa.ReadOnly = true;
            this.dgvKorpa.RowHeadersVisible = false;
            this.dgvKorpa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorpa.Size = new System.Drawing.Size(640, 150);
            this.dgvKorpa.TabIndex = 18;
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUkupno.ForeColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.lblUkupno.Location = new System.Drawing.Point(690, 450);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.TabIndex = 19;
            this.lblUkupno.Text = "Ukupno: 0,00 RSD";
            // 
            // btnUkloni
            // 
            this.btnUkloni.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnUkloni.FlatAppearance.BorderSize = 0;
            this.btnUkloni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUkloni.ForeColor = System.Drawing.Color.White;
            this.btnUkloni.Location = new System.Drawing.Point(690, 500);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(310, 38);
            this.btnUkloni.TabIndex = 20;
            this.btnUkloni.Text = "Ukloni iz korpe";
            this.btnUkloni.UseVisualStyleBackColor = false;
            // 
            // btnKupi
            // 
            this.btnKupi.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnKupi.FlatAppearance.BorderSize = 0;
            this.btnKupi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKupi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKupi.ForeColor = System.Drawing.Color.White;
            this.btnKupi.Location = new System.Drawing.Point(690, 548);
            this.btnKupi.Name = "btnKupi";
            this.btnKupi.Size = new System.Drawing.Size(310, 50);
            this.btnKupi.TabIndex = 21;
            this.btnKupi.Text = "KUPI";
            this.btnKupi.UseVisualStyleBackColor = false;
            // 
            // FormPonuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 250, 252);
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.Controls.Add(this.btnKupi);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.dgvKorpa);
            this.Controls.Add(this.lblKorpa);
            this.Controls.Add(this.btnDodajUKorpu);
            this.Controls.Add(this.nudKolicina);
            this.Controls.Add(this.lblKolicina);
            this.Controls.Add(this.dgvPonuda);
            this.Controls.Add(this.btnPrikaziSve);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.nudCenaDo);
            this.Controls.Add(this.lblCenaDo);
            this.Controls.Add(this.nudCenaOd);
            this.Controls.Add(this.lblCenaOd);
            this.Controls.Add(this.txtBoja);
            this.Controls.Add(this.lblBoja);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPonuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ponuda cveća";
            ((System.ComponentModel.ISupportInitialize)(this.nudCenaOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenaDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPonuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorpa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblBoja;
        private System.Windows.Forms.TextBox txtBoja;
        private System.Windows.Forms.Label lblCenaOd;
        private System.Windows.Forms.NumericUpDown nudCenaOd;
        private System.Windows.Forms.Label lblCenaDo;
        private System.Windows.Forms.NumericUpDown nudCenaDo;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Button btnPrikaziSve;
        private System.Windows.Forms.DataGridView dgvPonuda;
        private System.Windows.Forms.Label lblKolicina;
        private System.Windows.Forms.NumericUpDown nudKolicina;
        private System.Windows.Forms.Button btnDodajUKorpu;
        private System.Windows.Forms.Label lblKorpa;
        private System.Windows.Forms.DataGridView dgvKorpa;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.Button btnKupi;
    }
}