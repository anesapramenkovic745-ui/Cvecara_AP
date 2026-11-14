namespace Cvecara_AP.Forms
{
    partial class FormCvece
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
            this.dgvCvece = new System.Windows.Forms.DataGridView();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblBoja = new System.Windows.Forms.Label();
            this.txtBoja = new System.Windows.Forms.TextBox();
            this.lblCena = new System.Windows.Forms.Label();
            this.nudCena = new System.Windows.Forms.NumericUpDown();
            this.lblKolicina = new System.Windows.Forms.Label();
            this.nudKolicina = new System.Windows.Forms.NumericUpDown();
            this.lblDobavljac = new System.Windows.Forms.Label();
            this.cmbDobavljac = new System.Windows.Forms.ComboBox();
            this.lblTipovi = new System.Windows.Forms.Label();
            this.clbTipovi = new System.Windows.Forms.CheckedListBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnOcisti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCvece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKolicina)).BeginInit();
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
            this.lblNaslov.Text = "Upravljanje cvećem";
            // 
            // dgvCvece
            // 
            this.dgvCvece.AllowUserToAddRows = false;
            this.dgvCvece.AllowUserToDeleteRows = false;
            this.dgvCvece.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCvece.BackgroundColor = System.Drawing.Color.White;
            this.dgvCvece.Location = new System.Drawing.Point(20, 70);
            this.dgvCvece.MultiSelect = false;
            this.dgvCvece.Name = "dgvCvece";
            this.dgvCvece.ReadOnly = true;
            this.dgvCvece.RowHeadersVisible = false;
            this.dgvCvece.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCvece.Size = new System.Drawing.Size(700, 510);
            this.dgvCvece.TabIndex = 1;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(750, 70);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.TabIndex = 2;
            this.lblNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(750, 92);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(330, 22);
            this.txtNaziv.TabIndex = 3;
            // 
            // lblBoja
            // 
            this.lblBoja.AutoSize = true;
            this.lblBoja.Location = new System.Drawing.Point(750, 125);
            this.lblBoja.Name = "lblBoja";
            this.lblBoja.TabIndex = 4;
            this.lblBoja.Text = "Boja";
            // 
            // txtBoja
            // 
            this.txtBoja.Location = new System.Drawing.Point(750, 147);
            this.txtBoja.Name = "txtBoja";
            this.txtBoja.Size = new System.Drawing.Size(330, 22);
            this.txtBoja.TabIndex = 5;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Location = new System.Drawing.Point(750, 180);
            this.lblCena.Name = "lblCena";
            this.lblCena.TabIndex = 6;
            this.lblCena.Text = "Cena (RSD)";
            // 
            // nudCena
            // 
            this.nudCena.DecimalPlaces = 2;
            this.nudCena.Location = new System.Drawing.Point(750, 202);
            this.nudCena.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudCena.Name = "nudCena";
            this.nudCena.Size = new System.Drawing.Size(330, 22);
            this.nudCena.TabIndex = 7;
            // 
            // lblKolicina
            // 
            this.lblKolicina.AutoSize = true;
            this.lblKolicina.Location = new System.Drawing.Point(750, 235);
            this.lblKolicina.Name = "lblKolicina";
            this.lblKolicina.TabIndex = 8;
            this.lblKolicina.Text = "Količina na stanju";
            // 
            // nudKolicina
            // 
            this.nudKolicina.Location = new System.Drawing.Point(750, 257);
            this.nudKolicina.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudKolicina.Name = "nudKolicina";
            this.nudKolicina.Size = new System.Drawing.Size(330, 22);
            this.nudKolicina.TabIndex = 9;
            // 
            // lblDobavljac
            // 
            this.lblDobavljac.AutoSize = true;
            this.lblDobavljac.Location = new System.Drawing.Point(750, 290);
            this.lblDobavljac.Name = "lblDobavljac";
            this.lblDobavljac.TabIndex = 10;
            this.lblDobavljac.Text = "Dobavljač";
            // 
            // cmbDobavljac
            // 
            this.cmbDobavljac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDobavljac.Location = new System.Drawing.Point(750, 312);
            this.cmbDobavljac.Name = "cmbDobavljac";
            this.cmbDobavljac.Size = new System.Drawing.Size(330, 24);
            this.cmbDobavljac.TabIndex = 11;
            // 
            // lblTipovi
            // 
            this.lblTipovi.AutoSize = true;
            this.lblTipovi.Location = new System.Drawing.Point(750, 345);
            this.lblTipovi.Name = "lblTipovi";
            this.lblTipovi.TabIndex = 12;
            this.lblTipovi.Text = "Tipovi cveća (može više)";
            // 
            // clbTipovi
            // 
            this.clbTipovi.CheckOnClick = true;
            this.clbTipovi.Location = new System.Drawing.Point(750, 367);
            this.clbTipovi.Name = "clbTipovi";
            this.clbTipovi.Size = new System.Drawing.Size(330, 106);
            this.clbTipovi.TabIndex = 13;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnDodaj.FlatAppearance.BorderSize = 0;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.ForeColor = System.Drawing.Color.White;
            this.btnDodaj.Location = new System.Drawing.Point(750, 490);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(160, 38);
            this.btnDodaj.TabIndex = 14;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnIzmeni.FlatAppearance.BorderSize = 0;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeni.ForeColor = System.Drawing.Color.White;
            this.btnIzmeni.Location = new System.Drawing.Point(920, 490);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(160, 38);
            this.btnIzmeni.TabIndex = 15;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnObrisi.FlatAppearance.BorderSize = 0;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.ForeColor = System.Drawing.Color.White;
            this.btnObrisi.Location = new System.Drawing.Point(750, 538);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(160, 38);
            this.btnObrisi.TabIndex = 16;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = false;
            // 
            // btnOcisti
            // 
            this.btnOcisti.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnOcisti.FlatAppearance.BorderSize = 0;
            this.btnOcisti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcisti.ForeColor = System.Drawing.Color.White;
            this.btnOcisti.Location = new System.Drawing.Point(920, 538);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(160, 38);
            this.btnOcisti.TabIndex = 17;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = false;
            // 
            // FormCvece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 250, 252);
            this.ClientSize = new System.Drawing.Size(1110, 600);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.clbTipovi);
            this.Controls.Add(this.lblTipovi);
            this.Controls.Add(this.cmbDobavljac);
            this.Controls.Add(this.lblDobavljac);
            this.Controls.Add(this.nudKolicina);
            this.Controls.Add(this.lblKolicina);
            this.Controls.Add(this.nudCena);
            this.Controls.Add(this.lblCena);
            this.Controls.Add(this.txtBoja);
            this.Controls.Add(this.lblBoja);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.dgvCvece);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCvece";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cveće";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCvece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.DataGridView dgvCvece;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblBoja;
        private System.Windows.Forms.TextBox txtBoja;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.NumericUpDown nudCena;
        private System.Windows.Forms.Label lblKolicina;
        private System.Windows.Forms.NumericUpDown nudKolicina;
        private System.Windows.Forms.Label lblDobavljac;
        private System.Windows.Forms.ComboBox cmbDobavljac;
        private System.Windows.Forms.Label lblTipovi;
        private System.Windows.Forms.CheckedListBox clbTipovi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnOcisti;
    }
}