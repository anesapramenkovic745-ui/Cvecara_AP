using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormCvece : Form
    {
        private CveceRepository repo = new CveceRepository();
        private DobavljacRepository dobavljacRepo = new DobavljacRepository();
        private TipCvecaRepository tipRepo = new TipCvecaRepository();
        private int izabraniId = 0;   // 0 = ništa nije izabrano

        public FormCvece()
        {
            InitializeComponent();
            btnDodaj.Click += btnDodaj_Click;
            btnIzmeni.Click += btnIzmeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += (s, e) => OcistiPolja();
            dgvCvece.SelectionChanged += dgvCvece_SelectionChanged;
            this.Load += FormCvece_Load;
        }

        private void FormCvece_Load(object sender, EventArgs e)
        {
            try
            {
                // padajuća lista dobavljača
                cmbDobavljac.DataSource = dobavljacRepo.VratiSve();
                cmbDobavljac.DisplayMember = "Naziv";
                cmbDobavljac.ValueMember = "DobavljacId";

                // kvačice za tipove
                foreach (TipCveca t in tipRepo.VratiSve())
                {
                    clbTipovi.Items.Add(t);
                }

                UcitajCvece();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajCvece()
        {
            dgvCvece.DataSource = repo.VratiSve();
            dgvCvece.Columns["CveceId"].HeaderText = "ID";
            dgvCvece.Columns["CveceId"].FillWeight = 25;
            dgvCvece.Columns["Kolicina"].HeaderText = "Količina";
            dgvCvece.Columns["Kolicina"].FillWeight = 40;
            dgvCvece.Columns["Cena"].FillWeight = 40;
            dgvCvece.Columns["Cena"].DefaultCellStyle.Format = "N2";
            dgvCvece.Columns["Dobavljac"].HeaderText = "Dobavljač";
            dgvCvece.Columns["Tipovi"].FillWeight = 120;
            OcistiPolja();
        }

        private void dgvCvece_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCvece.CurrentRow == null) return;
            Cvece c = dgvCvece.CurrentRow.DataBoundItem as Cvece;
            if (c == null) return;

            izabraniId = c.CveceId;
            txtNaziv.Text = c.Naziv;
            txtBoja.Text = c.Boja;
            nudCena.Value = c.Cena;
            nudKolicina.Value = c.Kolicina;
            cmbDobavljac.SelectedValue = c.DobavljacId;

            // štikliraj tipove ovog cveća
            List<int> tipIds = repo.VratiTipIds(c.CveceId);
            for (int i = 0; i < clbTipovi.Items.Count; i++)
            {
                TipCveca t = (TipCveca)clbTipovi.Items[i];
                clbTipovi.SetItemChecked(i, tipIds.Contains(t.TipId));
            }
        }

        private void OcistiPolja()
        {
            dgvCvece.CurrentCell = null;
            dgvCvece.ClearSelection();

            izabraniId = 0;
            txtNaziv.Clear();
            txtBoja.Clear();
            nudCena.Value = 0;
            nudKolicina.Value = 0;
            if (cmbDobavljac.Items.Count > 0) cmbDobavljac.SelectedIndex = 0;
            for (int i = 0; i < clbTipovi.Items.Count; i++)
                clbTipovi.SetItemChecked(i, false);
            txtNaziv.Focus();
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Unesite naziv cveća.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBoja.Text))
            {
                MessageBox.Show("Unesite boju.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoja.Focus();
                return false;
            }
            if (nudCena.Value <= 0)
            {
                MessageBox.Show("Cena mora biti veća od 0.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCena.Focus();
                return false;
            }
            if (cmbDobavljac.SelectedValue == null)
            {
                MessageBox.Show("Izaberite dobavljača.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (clbTipovi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Izaberite bar jedan tip cveća.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Cvece NapraviIzPolja()
        {
            Cvece c = new Cvece();
            c.CveceId = izabraniId;
            c.Naziv = txtNaziv.Text.Trim();
            c.Boja = txtBoja.Text.Trim();
            c.Cena = nudCena.Value;
            c.Kolicina = Convert.ToInt32(nudKolicina.Value);
            c.DobavljacId = Convert.ToInt32(cmbDobavljac.SelectedValue);
            return c;
        }

        private List<int> IzabraniTipovi()
        {
            List<int> ids = new List<int>();
            foreach (object item in clbTipovi.CheckedItems)
            {
                ids.Add(((TipCveca)item).TipId);
            }
            return ids;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Dodaj(NapraviIzPolja(), IzabraniTipovi());
                UcitajCvece();
                MessageBox.Show("Cveće je dodato.", "Uspeh",
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
                MessageBox.Show("Izaberite cveće iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidacijaUnosa()) return;
            try
            {
                repo.Izmeni(NapraviIzPolja(), IzabraniTipovi());
                UcitajCvece();
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
                MessageBox.Show("Izaberite cveće iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult odgovor = MessageBox.Show("Da li sigurno želite da obrišete cveće?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odgovor != DialogResult.Yes) return;

            try
            {
                repo.Obrisi(izabraniId);
                UcitajCvece();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cveće nije moguće obrisati (verovatno je već u nekoj porudžbini).\n\n" +
                    ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}