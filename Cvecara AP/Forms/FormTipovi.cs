using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormTipovi : Form
    {
        private TipCvecaRepository repo = new TipCvecaRepository();
        private int izabraniId = 0;   // 0 = ništa nije izabrano

        public FormTipovi()
        {
            InitializeComponent();
            btnDodaj.Click += btnDodaj_Click;
            btnIzmeni.Click += btnIzmeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += (s, e) => OcistiPolja();
            dgvTipovi.SelectionChanged += dgvTipovi_SelectionChanged;
            this.Load += (s, e) => UcitajTipove();
        }

        private void UcitajTipove()
        {
            try
            {
                dgvTipovi.DataSource = repo.VratiSve();
                dgvTipovi.Columns["TipId"].HeaderText = "ID";
                dgvTipovi.Columns["TipId"].FillWeight = 25;
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTipovi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipovi.CurrentRow == null) return;
            TipCveca t = dgvTipovi.CurrentRow.DataBoundItem as TipCveca;
            if (t == null) return;

            izabraniId = t.TipId;
            txtNaziv.Text = t.Naziv;
        }

        private void OcistiPolja()
        {
            izabraniId = 0;
            txtNaziv.Clear();
            dgvTipovi.ClearSelection();
            txtNaziv.Focus();
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Unesite naziv tipa.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return false;
            }
            return true;
        }

        private TipCveca NapraviIzPolja()
        {
            TipCveca t = new TipCveca();
            t.TipId = izabraniId;
            t.Naziv = txtNaziv.Text.Trim();
            return t;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Dodaj(NapraviIzPolja());
                UcitajTipove();
                MessageBox.Show("Tip je dodat.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                PrikaziGresku(ex, "dodavanju");
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (izabraniId == 0)
            {
                MessageBox.Show("Izaberite tip iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Izmeni(NapraviIzPolja());
                UcitajTipove();
                MessageBox.Show("Tip je izmenjen.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                PrikaziGresku(ex, "izmeni");
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (izabraniId == 0)
            {
                MessageBox.Show("Izaberite tip iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult odgovor = MessageBox.Show("Da li sigurno želite da obrišete tip?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odgovor != DialogResult.Yes) return;

            try
            {
                repo.Obrisi(izabraniId);
                UcitajTipove();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Tip nije moguće obrisati (verovatno je dodeljen nekom cveću).\n\n" +
                    ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrikaziGresku(MySqlException ex, string akcija)
        {
            if (ex.Number == 1062)   // 1062 = duplikat jedinstvene vrednosti
            {
                MessageBox.Show("Tip sa tim nazivom već postoji.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Greška pri " + akcija + ":\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}