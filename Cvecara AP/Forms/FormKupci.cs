using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormKupci : Form
    {
        private KorisnikRepository repo = new KorisnikRepository();
        private int izabraniId = 0;   // 0 = ništa nije izabrano

        public FormKupci()
        {
            InitializeComponent();
            btnDodaj.Click += btnDodaj_Click;
            btnIzmeni.Click += btnIzmeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += (s, e) => OcistiPolja();
            dgvKupci.SelectionChanged += dgvKupci_SelectionChanged;
            this.Load += (s, e) => UcitajKupce();
        }

        private void UcitajKupce()
        {
            try
            {
                dgvKupci.DataSource = repo.VratiSve("KUPAC");
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
            dgvKupci.Columns["KorisniciId"].HeaderText = "ID";
            dgvKupci.Columns["Telefon"].HeaderText = "Telefon";
            dgvKupci.Columns["Tip"].Visible = false;
            dgvKupci.Columns["KorisniciId"].FillWeight = 30;
        }

        private void dgvKupci_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKupci.CurrentRow == null) return;
            Korisnik k = dgvKupci.CurrentRow.DataBoundItem as Korisnik;
            if (k == null) return;

            izabraniId = k.KorisniciId;
            txtIme.Text = k.Ime;
            txtPrezime.Text = k.Prezime;
            txtEmail.Text = k.Email;
            txtTelefon.Text = k.Telefon;
            txtAdresa.Text = k.Adresa;
        }

        private void OcistiPolja()
        {
            izabraniId = 0;
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();
            txtAdresa.Clear();
            dgvKupci.ClearSelection();
            txtIme.Focus();
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                MessageBox.Show("Unesite ime.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIme.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                MessageBox.Show("Unesite prezime.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrezime.Focus();
                return false;
            }
            return true;
        }

        private Korisnik NapraviIzPolja()
        {
            Korisnik k = new Korisnik();
            k.KorisniciId = izabraniId;
            k.Ime = txtIme.Text.Trim();
            k.Prezime = txtPrezime.Text.Trim();
            k.Email = txtEmail.Text.Trim();
            k.Telefon = txtTelefon.Text.Trim();
            k.Adresa = txtAdresa.Text.Trim();
            k.Tip = "KUPAC";
            return k;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Dodaj(NapraviIzPolja());
                UcitajKupce();
                MessageBox.Show("Kupac je dodat.", "Uspeh",
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
                MessageBox.Show("Izaberite kupca iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Izmeni(NapraviIzPolja());
                UcitajKupce();
                MessageBox.Show("Podaci su izmenjeni.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri izmeni:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (izabraniId == 0)
            {
                MessageBox.Show("Izaberite kupca iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult odgovor = MessageBox.Show("Da li sigurno želite da obrišete kupca?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odgovor != DialogResult.Yes) return;

            try
            {
                repo.Obrisi(izabraniId);
                UcitajKupce();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kupca nije moguće obrisati (verovatno ima porudžbine).\n\n" +
                    ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}