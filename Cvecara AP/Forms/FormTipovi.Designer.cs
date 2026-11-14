namespace Cvecara_AP.Forms
{
    partial class FormTipovi
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
            this.dgvTipovi = new System.Windows.Forms.DataGridView();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnOcisti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipovi)).BeginInit();
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
            this.lblNaslov.Text = "Upravljanje tipovima cveća";
            // 
            // dgvTipovi
            // 
            this.dgvTipovi.AllowUserToAddRows = false;
            this.dgvTipovi.AllowUserToDeleteRows = false;
            this.dgvTipovi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipovi.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipovi.Location = new System.Drawing.Point(20, 70);
            this.dgvTipovi.MultiSelect = false;
            this.dgvTipovi.Name = "dgvTipovi";
            this.dgvTipovi.ReadOnly = true;
            this.dgvTipovi.RowHeadersVisible = false;
            this.dgvTipovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipovi.Size = new System.Drawing.Size(440, 380);
            this.dgvTipovi.TabIndex = 1;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(490, 70);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.TabIndex = 2;
            this.lblNaziv.Text = "Naziv tipa";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(490, 92);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(260, 22);
            this.txtNaziv.TabIndex = 3;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnDodaj.FlatAppearance.BorderSize = 0;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.ForeColor = System.Drawing.Color.White;
            this.btnDodaj.Location = new System.Drawing.Point(490, 140);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(125, 38);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnIzmeni.FlatAppearance.BorderSize = 0;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeni.ForeColor = System.Drawing.Color.White;
            this.btnIzmeni.Location = new System.Drawing.Point(625, 140);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(125, 38);
            this.btnIzmeni.TabIndex = 5;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnObrisi.FlatAppearance.BorderSize = 0;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.ForeColor = System.Drawing.Color.White;
            this.btnObrisi.Location = new System.Drawing.Point(490, 188);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(125, 38);
            this.btnObrisi.TabIndex = 6;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = false;
            // 
            // btnOcisti
            // 
            this.btnOcisti.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnOcisti.FlatAppearance.BorderSize = 0;
            this.btnOcisti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcisti.ForeColor = System.Drawing.Color.White;
            this.btnOcisti.Location = new System.Drawing.Point(625, 188);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(125, 38);
            this.btnOcisti.TabIndex = 7;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = false;
            // 
            // FormTipovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 250, 252);
            this.ClientSize = new System.Drawing.Size(780, 470);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.dgvTipovi);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTipovi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipovi cveća";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.DataGridView dgvTipovi;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnOcisti;
    }
}