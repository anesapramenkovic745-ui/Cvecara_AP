using Cvecara_AP.Data;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormKupac : Form
    {
        private FormLogin loginForma;

        public FormKupac(FormLogin login)
        {
            InitializeComponent();
            loginForma = login;

            lblDobrodosli.Text = "Dobrodošli, " + Sesija.TrenutniKorisnik.KorisnickoIme + "!";

            btnPonuda.Click += (s, e) => new FormPonuda().ShowDialog();
            btnMojePorudzbine.Click += (s, e) => Uskoro("Moje porudžbine");
            btnOdjava.Click += btnOdjava_Click;
            this.FormClosed += FormKupac_FormClosed;
        }

        private void Uskoro(string naziv)
        {
            MessageBox.Show("Deo \"" + naziv + "\" pravimo u narednom koraku.");
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Sesija.TrenutniKorisnik = null;
            loginForma.OcistiPolja();
            loginForma.Show();
            this.Hide();
        }

        // Ako se prozor zatvori na X, gasi se cela aplikacija
        private void FormKupac_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}