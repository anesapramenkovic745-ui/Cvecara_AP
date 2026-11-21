using Cvecara_AP.Data;
using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormLogin : Form
    {
        private KorisnikAplikacijeRepository repo = new KorisnikAplikacijeRepository();

        public FormLogin()
        {
            InitializeComponent();
            btnPrijava.Click += btnPrijava_Click;
            lblRegistracija.Click += lblRegistracija_Click;
        }

        public void OcistiPolja()
        {
            txtKorisnickoIme.Clear();
            txtLozinka.Clear();
            txtKorisnickoIme.Focus();
        }

        private bool ValidacijaUnosa(string korisnickoIme, string lozinka)
        {
            if (string.IsNullOrWhiteSpace(korisnickoIme))
            {
                MessageBox.Show("Unesite korisničko ime.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKorisnickoIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(lozinka))
            {
                MessageBox.Show("Unesite lozinku.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLozinka.Focus();
                return false;
            }

            return true;
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            string korisnickoIme = txtKorisnickoIme.Text.Trim();
            string lozinka = txtLozinka.Text;

            if (!ValidacijaUnosa(korisnickoIme, lozinka))
            {
                return;
            }

            try
            {
                KorisnikAplikacije korisnik = repo.Prijavi(korisnickoIme, lozinka);

                if (korisnik == null)
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLozinka.Clear();
                    txtLozinka.Focus();
                    return;
                }

                Sesija.TrenutniKorisnik = korisnik;

                if (korisnik.JeAdmin())
                {
                    FormAdmin adminForma = new FormAdmin(this);
                    adminForma.Show();
                    this.Hide();
                }
                else
                {
                    FormKupac kupacForma = new FormKupac(this);
                    kupacForma.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom povezivanja sa bazom:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblRegistracija_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registraciju pravimo u jednom od narednih koraka.");
        }
    }
}