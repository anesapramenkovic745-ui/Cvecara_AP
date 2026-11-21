using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormPorudzbine : Form
    {
        private PorudzbinaRepository repo = new PorudzbinaRepository();

        public FormPorudzbine()
        {
            InitializeComponent();
            btnPretrazi.Click += (s, e) => UcitajPorudzbine();
            btnPrikaziSve.Click += btnPrikaziSve_Click;
            dgvPorudzbine.SelectionChanged += dgvPorudzbine_SelectionChanged;
            this.AcceptButton = btnPretrazi;   // Enter pokreće pretragu
            this.Load += (s, e) => UcitajPorudzbine();
        }

        private void UcitajPorudzbine()
        {
            try
            {
                DateTime? od = dtpOd.Checked ? dtpOd.Value.Date : (DateTime?)null;
                DateTime? doDatuma = dtpDo.Checked ? dtpDo.Value.Date : (DateTime?)null;

                dgvPorudzbine.DataSource = repo.Pretrazi(txtPretraga.Text, od, doDatuma);

                dgvPorudzbine.Columns["PorudzbinaId"].HeaderText = "Br. porudžbine";
                dgvPorudzbine.Columns["Datum"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvPorudzbine.Columns["UkupnaCena"].HeaderText = "Ukupno (RSD)";
                dgvPorudzbine.Columns["UkupnaCena"].DefaultCellStyle.Format = "N2";

                PrikaziStavke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtPretraga.Clear();
            dtpOd.Checked = false;
            dtpDo.Checked = false;
            UcitajPorudzbine();
        }

        private void dgvPorudzbine_SelectionChanged(object sender, EventArgs e)
        {
            PrikaziStavke();
        }

        private void PrikaziStavke()
        {
            if (dgvPorudzbine.CurrentRow == null)
            {
                dgvStavke.DataSource = null;
                lblStavke.Text = "Stavke izabrane porudžbine";
                return;
            }

            Porudzbina p = dgvPorudzbine.CurrentRow.DataBoundItem as Porudzbina;
            if (p == null) return;

            try
            {
                dgvStavke.DataSource = repo.VratiStavke(p.PorudzbinaId);

                dgvStavke.Columns["Naziv"].HeaderText = "Cveće";
                dgvStavke.Columns["Kolicina"].HeaderText = "Količina";
                dgvStavke.Columns["CenaPoJedinici"].HeaderText = "Cena po komadu";
                dgvStavke.Columns["CenaPoJedinici"].DefaultCellStyle.Format = "N2";
                dgvStavke.Columns["Iznos"].DefaultCellStyle.Format = "N2";

                lblStavke.Text = "Stavke porudžbine br. " + p.PorudzbinaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju stavki:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}