using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormDobavljaci : Form
    {
        private DobavljacRepository repo = new DobavljacRepository();
        private int izabraniId = 0;   // 0 = ništa nije izabrano

        public FormDobavljaci()
        {
            InitializeComponent();
            btnDodaj.Click += btnDodaj_Click;
            btnIzmeni.Click += btnIzmeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += (s, e) => OcistiPolja();
            dgvDobavljaci.SelectionChanged += dgvDobavljaci_SelectionChanged;
            this.Load += (s, e) => UcitajDobavljace();
        }

        private void UcitajDobavljace()
        {
            try
            {
                dgvDobavljaci.DataSource = repo.VratiSve();
                PodesiKolone();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiKolone()
        {
            dgvDobavljaci.Columns["DobavljacId"].HeaderText = "ID";
            dgvDobavljaci.Columns["DobavljacId"].FillWeight = 30;
            dgvDobavljaci.Columns["KontaktOsoba"].HeaderText = "Kontakt osoba";
        }

        private void dgvDobavljaci_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDobavljaci.CurrentRow == null) return;
            Dobavljac d = dgvDobavljaci.CurrentRow.DataBoundItem as Dobavljac;
            if (d == null) return;

            izabraniId = d.DobavljacId;
            txtNaziv.Text = d.Naziv;
            txtKontakt.Text = d.KontaktOsoba;
            txtTelefon.Text = d.Telefon;
            txtEmail.Text = d.Email;
            txtAdresa.Text = d.Adresa;
        }

        private void OcistiPolja()
        {
            izabraniId = 0;
            txtNaziv.Clear();
            txtKontakt.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtAdresa.Clear();
            dgvDobavljaci.ClearSelection();
            txtNaziv.Focus();
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Unesite naziv dobavljača.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return false;
            }
            return true;
        }

        private Dobavljac NapraviIzPolja()
        {
            Dobavljac d = new Dobavljac();
            d.DobavljacId = izabraniId;
            d.Naziv = txtNaziv.Text.Trim();
            d.KontaktOsoba = txtKontakt.Text.Trim();
            d.Telefon = txtTelefon.Text.Trim();
            d.Email = txtEmail.Text.Trim();
            d.Adresa = txtAdresa.Text.Trim();
            return d;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Dodaj(NapraviIzPolja());
                UcitajDobavljace();
                MessageBox.Show("Dobavljač je dodat.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (izabraniId == 0)
            {
                MessageBox.Show("Izaberite dobavljača iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Izmeni(NapraviIzPolja());
                UcitajDobavljace();
                MessageBox.Show("Podaci su izmenjeni.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri izmenNi:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (izabraniId == 0)
            {
                MessageBox.Show("Izaberite dobavljača iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult odgovor = MessageBox.Show("Da li sigurno želite da obrišete dobavljača?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odgovor != DialogResult.Yes) return;

            try
            {
                repo.Obrisi(izabraniId);
                UcitajDobavljace();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dobavljača nije moguće obrisati (verovatno ima cveće).\n\n" +
                    ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}