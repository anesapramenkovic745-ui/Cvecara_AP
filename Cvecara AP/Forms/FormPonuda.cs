using Cvecara_AP.Data;
using Cvecara_AP.Models;
using Cvecara_AP.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Cvecara_AP.Forms
{
    public partial class FormPonuda : Form
    {
        private CveceRepository repo = new CveceRepository();
        private TipCvecaRepository tipRepo = new TipCvecaRepository();
        private PorudzbinaRepository porudzbinaRepo = new PorudzbinaRepository();

        // korpa je lista stavki; BindingList omogućava automatsko osvežavanje tabele
        private BindingList<StavkaKorpe> korpa = new BindingList<StavkaKorpe>();

        public FormPonuda()
        {
            InitializeComponent();
            btnPretrazi.Click += (s, e) => UcitajPonudu();
            btnPrikaziSve.Click += btnPonisti_Click;
            btnDodajUKorpu.Click += btnDodajUKorpu_Click;
            btnUkloni.Click += btnUkloni_Click;
            btnKupi.Click += btnKupi_Click;
            korpa.ListChanged += (s, e) => OsveziUkupno();
            this.AcceptButton = btnPretrazi;   // Enter pokreće pretragu
            this.Load += FormPonuda_Load;
        }

        private void FormPonuda_Load(object sender, EventArgs e)
        {
            try
            {
                List<TipCveca> tipovi = tipRepo.VratiSve();
                tipovi.Insert(0, new TipCveca(0, "Svi tipovi"));
                cmbTip.DataSource = tipovi;
                cmbTip.DisplayMember = "Naziv";
                cmbTip.ValueMember = "TipId";

                dgvKorpa.DataSource = korpa;
                PodesiKorpu();

                UcitajPonudu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiKorpu()
        {
            dgvKorpa.Columns["CveceId"].Visible = false;
            dgvKorpa.Columns["Cena"].HeaderText = "Cena (RSD)";
            dgvKorpa.Columns["Cena"].DefaultCellStyle.Format = "N2";
            dgvKorpa.Columns["Iznos"].HeaderText = "Iznos (RSD)";
            dgvKorpa.Columns["Iznos"].DefaultCellStyle.Format = "N2";
            dgvKorpa.Columns["Kolicina"].HeaderText = "Količina";
        }

        private void UcitajPonudu()
        {
            if (nudCenaDo.Value > 0 && nudCenaOd.Value > nudCenaDo.Value)
            {
                MessageBox.Show("Cena \"od\" ne može biti veća od cene \"do\".", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int tipId = Convert.ToInt32(cmbTip.SelectedValue);

                dgvPonuda.DataSource = repo.Pretrazi(txtNaziv.Text, txtBoja.Text,
                    nudCenaOd.Value, nudCenaDo.Value, tipId);

                dgvPonuda.Columns["CveceId"].Visible = false;
                dgvPonuda.Columns["Dobavljac"].Visible = false;

                dgvPonuda.Columns["Cena"].HeaderText = "Cena (RSD)";
                dgvPonuda.Columns["Cena"].DefaultCellStyle.Format = "N2";
                dgvPonuda.Columns["Kolicina"].HeaderText = "Na stanju";
                dgvPonuda.Columns["Tipovi"].HeaderText = "Tipovi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            txtNaziv.Clear();
            txtBoja.Clear();
            nudCenaOd.Value = 0;
            nudCenaDo.Value = 0;
            cmbTip.SelectedIndex = 0;
            UcitajPonudu();
        }

        private void btnDodajUKorpu_Click(object sender, EventArgs e)
        {
            Cvece izabrano = dgvPonuda.CurrentRow == null
                ? null : dgvPonuda.CurrentRow.DataBoundItem as Cvece;

            if (izabrano == null)
            {
                MessageBox.Show("Izaberite cveće iz ponude.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trazeno = Convert.ToInt32(nudKolicina.Value);

            // ako je cvet već u korpi, uvećavamo količinu
            StavkaKorpe postojeca = korpa.FirstOrDefault(s => s.CveceId == izabrano.CveceId);
            int ukupnoTrazeno = trazeno + (postojeca == null ? 0 : postojeca.Kolicina);

            if (ukupnoTrazeno > izabrano.Kolicina)
            {
                MessageBox.Show("Na stanju ima samo " + izabrano.Kolicina + " kom.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (postojeca != null)
            {
                postojeca.Kolicina = ukupnoTrazeno;
                korpa.ResetBindings();
            }
            else
            {
                StavkaKorpe s = new StavkaKorpe();
                s.CveceId = izabrano.CveceId;
                s.Naziv = izabrano.Naziv;
                s.Boja = izabrano.Boja;
                s.Cena = izabrano.Cena;
                s.Kolicina = trazeno;
                korpa.Add(s);
            }

            nudKolicina.Value = 1;
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            StavkaKorpe s = dgvKorpa.CurrentRow == null
                ? null : dgvKorpa.CurrentRow.DataBoundItem as StavkaKorpe;

            if (s == null)
            {
                MessageBox.Show("Izaberite stavku u korpi.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            korpa.Remove(s);
        }

        private void OsveziUkupno()
        {
            decimal ukupno = korpa.Sum(s => s.Iznos);
            lblUkupno.Text = "Ukupno: " + ukupno.ToString("N2") + " RSD";
        }

        private void btnKupi_Click(object sender, EventArgs e)
        {
            if (korpa.Count == 0)
            {
                MessageBox.Show("Korpa je prazna.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? kupacId = Sesija.TrenutniKorisnik.KupacId;
            if (kupacId == null)
            {
                MessageBox.Show("Ovaj nalog nije povezan sa kupcem.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal ukupno = korpa.Sum(s => s.Iznos);
            DialogResult odgovor = MessageBox.Show(
                "Ukupan iznos je " + ukupno.ToString("N2") + " RSD.\nDa li želite da kupite?",
                "Potvrda kupovine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odgovor != DialogResult.Yes) return;

            try
            {
                int brojPorudzbine = porudzbinaRepo.Kupi(kupacId.Value, korpa.ToList());

                korpa.Clear();
                UcitajPonudu();   // osvežava prikaz stanja

                MessageBox.Show("Uspešna kupovina!\nBroj porudžbine: " + brojPorudzbine,
                    "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kupovina nije uspela:\n" + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UcitajPonudu();
            }
        }
    }
}