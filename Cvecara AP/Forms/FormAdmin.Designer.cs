namespace Cvecara_AP.Forms
{
    partial class FormAdmin
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
            this.pnlMeni = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnKupci = new System.Windows.Forms.Button();
            this.btnDobavljaci = new System.Windows.Forms.Button();
            this.btnTipovi = new System.Windows.Forms.Button();
            this.btnCvece = new System.Windows.Forms.Button();
            this.btnPorudzbine = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.pnlSadrzaj = new System.Windows.Forms.Panel();
            this.lblDobrodosli = new System.Windows.Forms.Label();
            this.pnlMeni.SuspendLayout();
            this.pnlSadrzaj.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMeni
            // 
            this.pnlMeni.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.pnlMeni.Controls.Add(this.btnOdjava);
            this.pnlMeni.Controls.Add(this.btnPorudzbine);
            this.pnlMeni.Controls.Add(this.btnCvece);
            this.pnlMeni.Controls.Add(this.btnTipovi);
            this.pnlMeni.Controls.Add(this.btnDobavljaci);
            this.pnlMeni.Controls.Add(this.btnKupci);
            this.pnlMeni.Controls.Add(this.lblLogo);
            this.pnlMeni.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMeni.Location = new System.Drawing.Point(0, 0);
            this.pnlMeni.Name = "pnlMeni";
            this.pnlMeni.Size = new System.Drawing.Size(240, 650);
            this.pnlMeni.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(40, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Cvećara";
            // 
            // btnKupci
            // 
            this.btnKupci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKupci.FlatAppearance.BorderSize = 0;
            this.btnKupci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKupci.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKupci.ForeColor = System.Drawing.Color.White;
            this.btnKupci.Location = new System.Drawing.Point(0, 110);
            this.btnKupci.Name = "btnKupci";
            this.btnKupci.Size = new System.Drawing.Size(240, 50);
            this.btnKupci.TabIndex = 1;
            this.btnKupci.Text = "Kupci";
            this.btnKupci.UseVisualStyleBackColor = true;
            // 
            // btnDobavljaci
            // 
            this.btnDobavljaci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDobavljaci.FlatAppearance.BorderSize = 0;
            this.btnDobavljaci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDobavljaci.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDobavljaci.ForeColor = System.Drawing.Color.White;
            this.btnDobavljaci.Location = new System.Drawing.Point(0, 165);
            this.btnDobavljaci.Name = "btnDobavljaci";
            this.btnDobavljaci.Size = new System.Drawing.Size(240, 50);
            this.btnDobavljaci.TabIndex = 2;
            this.btnDobavljaci.Text = "Dobavljači";
            this.btnDobavljaci.UseVisualStyleBackColor = true;
            // 
            // btnTipovi
            // 
            this.btnTipovi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipovi.FlatAppearance.BorderSize = 0;
            this.btnTipovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipovi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTipovi.ForeColor = System.Drawing.Color.White;
            this.btnTipovi.Location = new System.Drawing.Point(0, 220);
            this.btnTipovi.Name = "btnTipovi";
            this.btnTipovi.Size = new System.Drawing.Size(240, 50);
            this.btnTipovi.TabIndex = 3;
            this.btnTipovi.Text = "Tipovi cveća";
            this.btnTipovi.UseVisualStyleBackColor = true;
            // 
            // btnCvece
            // 
            this.btnCvece.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCvece.FlatAppearance.BorderSize = 0;
            this.btnCvece.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCvece.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCvece.ForeColor = System.Drawing.Color.White;
            this.btnCvece.Location = new System.Drawing.Point(0, 275);
            this.btnCvece.Name = "btnCvece";
            this.btnCvece.Size = new System.Drawing.Size(240, 50);
            this.btnCvece.TabIndex = 4;
            this.btnCvece.Text = "Cveće";
            this.btnCvece.UseVisualStyleBackColor = true;
            // 
            // btnPorudzbine
            // 
            this.btnPorudzbine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPorudzbine.FlatAppearance.BorderSize = 0;
            this.btnPorudzbine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPorudzbine.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPorudzbine.ForeColor = System.Drawing.Color.White;
            this.btnPorudzbine.Location = new System.Drawing.Point(0, 330);
            this.btnPorudzbine.Name = "btnPorudzbine";
            this.btnPorudzbine.Size = new System.Drawing.Size(240, 50);
            this.btnPorudzbine.TabIndex = 5;
            this.btnPorudzbine.Text = "Porudžbine";
            this.btnPorudzbine.UseVisualStyleBackColor = true;
            // 
            // btnOdjava
            // 
            this.btnOdjava.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdjava.FlatAppearance.BorderSize = 0;
            this.btnOdjava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdjava.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOdjava.ForeColor = System.Drawing.Color.White;
            this.btnOdjava.Location = new System.Drawing.Point(0, 590);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(240, 50);
            this.btnOdjava.TabIndex = 6;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            // 
            // pnlSadrzaj
            // 
            this.pnlSadrzaj.BackColor = System.Drawing.Color.FromArgb(255, 250, 252);
            this.pnlSadrzaj.Controls.Add(this.lblDobrodosli);
            this.pnlSadrzaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSadrzaj.Location = new System.Drawing.Point(240, 0);
            this.pnlSadrzaj.Name = "pnlSadrzaj";
            this.pnlSadrzaj.Size = new System.Drawing.Size(960, 650);
            this.pnlSadrzaj.TabIndex = 1;
            // 
            // lblDobrodosli
            // 
            this.lblDobrodosli.AutoSize = true;
            this.lblDobrodosli.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDobrodosli.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblDobrodosli.Location = new System.Drawing.Point(40, 40);
            this.lblDobrodosli.Name = "lblDobrodosli";
            this.lblDobrodosli.TabIndex = 0;
            this.lblDobrodosli.Text = "Dobrodošli, administratore!";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlSadrzaj);
            this.Controls.Add(this.pnlMeni);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cvećara - Administrator";
            this.pnlMeni.ResumeLayout(false);
            this.pnlMeni.PerformLayout();
            this.pnlSadrzaj.ResumeLayout(false);
            this.pnlSadrzaj.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMeni;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnKupci;
        private System.Windows.Forms.Button btnDobavljaci;
        private System.Windows.Forms.Button btnTipovi;
        private System.Windows.Forms.Button btnCvece;
        private System.Windows.Forms.Button btnPorudzbine;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Panel pnlSadrzaj;
        private System.Windows.Forms.Label lblDobrodosli;
    }
}