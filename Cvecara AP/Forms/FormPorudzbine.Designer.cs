namespace Cvecara_AP.Forms
{
    partial class FormPorudzbine
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
            this.lblPretraga = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.lblOd = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.lblDo = new System.Windows.Forms.Label();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.btnPrikaziSve = new System.Windows.Forms.Button();
            this.dgvPorudzbine = new System.Windows.Forms.DataGridView();
            this.lblStavke = new System.Windows.Forms.Label();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorudzbine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
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
            this.lblNaslov.Text = "Pregled porudžbina";
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(20, 70);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.TabIndex = 1;
            this.lblPretraga.Text = "Kupac ili broj porudžbine";
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(20, 92);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(250, 22);
            this.txtPretraga.TabIndex = 2;
            // 
            // lblOd
            // 
            this.lblOd.AutoSize = true;
            this.lblOd.Location = new System.Drawing.Point(290, 70);
            this.lblOd.Name = "lblOd";
            this.lblOd.TabIndex = 3;
            this.lblOd.Text = "Od datuma";
            // 
            // dtpOd
            // 
            this.dtpOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOd.Location = new System.Drawing.Point(290, 92);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.ShowCheckBox = true;
            this.dtpOd.Checked = false;
            this.dtpOd.Size = new System.Drawing.Size(150, 22);
            this.dtpOd.TabIndex = 4;
            // 
            // lblDo
            // 
            this.lblDo.AutoSize = true;
            this.lblDo.Location = new System.Drawing.Point(460, 70);
            this.lblDo.Name = "lblDo";
            this.lblDo.TabIndex = 5;
            this.lblDo.Text = "Do datuma";
            // 
            // dtpDo
            // 
            this.dtpDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDo.Location = new System.Drawing.Point(460, 92);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.ShowCheckBox = true;
            this.dtpDo.Checked = false;
            this.dtpDo.Size = new System.Drawing.Size(150, 22);
            this.dtpDo.TabIndex = 6;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackColor = System.Drawing.Color.FromArgb(214, 51, 108);
            this.btnPretrazi.FlatAppearance.BorderSize = 0;
            this.btnPretrazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPretrazi.ForeColor = System.Drawing.Color.White;
            this.btnPretrazi.Location = new System.Drawing.Point(640, 85);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(150, 36);
            this.btnPretrazi.TabIndex = 7;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // btnPrikaziSve
            // 
            this.btnPrikaziSve.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnPrikaziSve.FlatAppearance.BorderSize = 0;
            this.btnPrikaziSve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikaziSve.ForeColor = System.Drawing.Color.White;
            this.btnPrikaziSve.Location = new System.Drawing.Point(800, 85);
            this.btnPrikaziSve.Name = "btnPrikaziSve";
            this.btnPrikaziSve.Size = new System.Drawing.Size(150, 36);
            this.btnPrikaziSve.TabIndex = 8;
            this.btnPrikaziSve.Text = "Prikaži sve";
            this.btnPrikaziSve.UseVisualStyleBackColor = false;
            // 
            // dgvPorudzbine
            // 
            this.dgvPorudzbine.AllowUserToAddRows = false;
            this.dgvPorudzbine.AllowUserToDeleteRows = false;
            this.dgvPorudzbine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPorudzbine.BackgroundColor = System.Drawing.Color.White;
            this.dgvPorudzbine.Location = new System.Drawing.Point(20, 140);
            this.dgvPorudzbine.MultiSelect = false;
            this.dgvPorudzbine.Name = "dgvPorudzbine";
            this.dgvPorudzbine.ReadOnly = true;
            this.dgvPorudzbine.RowHeadersVisible = false;
            this.dgvPorudzbine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorudzbine.Size = new System.Drawing.Size(930, 210);
            this.dgvPorudzbine.TabIndex = 9;
            // 
            // lblStavke
            // 
            this.lblStavke.AutoSize = true;
            this.lblStavke.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStavke.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblStavke.Location = new System.Drawing.Point(20, 365);
            this.lblStavke.Name = "lblStavke";
            this.lblStavke.TabIndex = 10;
            this.lblStavke.Text = "Stavke izabrane porudžbine";
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStavke.BackgroundColor = System.Drawing.Color.White;
            this.dgvStavke.Location = new System.Drawing.Point(20, 395);
            this.dgvStavke.MultiSelect = false;
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            this.dgvStavke.RowHeadersVisible = false;
            this.dgvStavke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStavke.Size = new System.Drawing.Size(930, 200);
            this.dgvStavke.TabIndex = 11;
            // 
            // FormPorudzbine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 250, 252);
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.lblStavke);
            this.Controls.Add(this.dgvPorudzbine);
            this.Controls.Add(this.btnPrikaziSve);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.lblDo);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.lblOd);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.lblPretraga);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPorudzbine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Porudžbine";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorudzbine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Label lblPretraga;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label lblOd;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.Label lblDo;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Button btnPrikaziSve;
        private System.Windows.Forms.DataGridView dgvPorudzbine;
        private System.Windows.Forms.Label lblStavke;
        private System.Windows.Forms.DataGridView dgvStavke;
    }
}