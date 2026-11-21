namespace Cvecara_AP.Forms
{
    partial class FormKupac
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
            this.btnPonuda = new System.Windows.Forms.Button();
            this.btnMojePorudzbine = new System.Windows.Forms.Button();
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
            this.pnlMeni.Controls.Add(this.btnMojePorudzbine);
            this.pnlMeni.Controls.Add(this.btnPonuda);
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
            // btnPonuda
            // 
            this.btnPonuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPonuda.FlatAppearance.BorderSize = 0;
            this.btnPonuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPonuda.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPonuda.ForeColor = System.Drawing.Color.White;
            this.btnPonuda.Location = new System.Drawing.Point(0, 110);
            this.btnPonuda.Name = "btnPonuda";
            this.btnPonuda.Size = new System.Drawing.Size(240, 50);
            this.btnPonuda.TabIndex = 1;
            this.btnPonuda.Text = "Ponuda cveća";
            this.btnPonuda.UseVisualStyleBackColor = true;
            // 
            // btnMojePorudzbine
            // 
            this.btnMojePorudzbine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMojePorudzbine.FlatAppearance.BorderSize = 0;
            this.btnMojePorudzbine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMojePorudzbine.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMojePorudzbine.ForeColor = System.Drawing.Color.White;
            this.btnMojePorudzbine.Location = new System.Drawing.Point(0, 165);
            this.btnMojePorudzbine.Name = "btnMojePorudzbine";
            this.btnMojePorudzbine.Size = new System.Drawing.Size(240, 50);
            this.btnMojePorudzbine.TabIndex = 2;
            this.btnMojePorudzbine.Text = "Moje porudžbine";
            this.btnMojePorudzbine.UseVisualStyleBackColor = true;
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
            this.btnOdjava.TabIndex = 3;
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
            this.lblDobrodosli.Text = "Dobrodošli!";
            // 
            // FormKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlSadrzaj);
            this.Controls.Add(this.pnlMeni);
            this.Name = "FormKupac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cvećara - Kupac";
            this.pnlMeni.ResumeLayout(false);
            this.pnlMeni.PerformLayout();
            this.pnlSadrzaj.ResumeLayout(false);
            this.pnlSadrzaj.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMeni;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnPonuda;
        private System.Windows.Forms.Button btnMojePorudzbine;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Panel pnlSadrzaj;
        private System.Windows.Forms.Label lblDobrodosli;
    }
}