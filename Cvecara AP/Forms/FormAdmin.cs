using Cvecara_AP.Data;
using System;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormAdmin : Form
    {
        private FormLogin loginForma;

        // Forma dobija login formu da bi je posle odjave mogla ponovo da prikaže
        public FormAdmin(FormLogin login)
        {
            InitializeComponent();
            loginForma = login;

            btnKupci.Click += (s, e) => new FormKupci().ShowDialog();
            btnDobavljaci.Click += (s, e) => new FormDobavljaci().ShowDialog();
            btnTipovi.Click += (s, e) => new FormTipovi().ShowDialog();
            btnCvece.Click += (s, e) => new FormCvece().ShowDialog();
            btnPorudzbine.Click += (s, e) => Uskoro("Porudžbine");
            btnOdjava.Click += btnOdjava_Click;
            this.FormClosed += FormAdmin_FormClosed;
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
        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}