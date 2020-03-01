using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Garaza.Entiteti;

namespace Garaza
{
    public partial class OrganizovanjeNedelje : Form
    {
        private IList<Operater> operateri;
        private Operater kontrolor;
        private Operater prva_smena;
        private Operater druga_smena;
        private Operater treca_smena;


        public OrganizovanjeNedelje()
        {
            InitializeComponent();
        }

        private void OrganizovanjeNedelje_Load(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                operateri = s.QueryOver<Operater>()
                                     .List<Operater>();
                List<string> operateriStr = new List<string>();
                foreach (Operater operater in operateri)
                {
                    operateriStr.Add(operater.Ime + " " + operater.Prezime + " " + operater.Jmbg);
                }
                lbOperateri.DataSource = operateriStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKontroler_Click(object sender, EventArgs e)
        {
            kontrolor = operateri[lbOperateri.SelectedIndex];
            labKontroler.Text = kontrolor.Ime + " " + kontrolor.Prezime;
        }

        private void btnPrvaSmena_Click(object sender, EventArgs e)
        {
            prva_smena = operateri[lbOperateri.SelectedIndex];
            labPrvaSmena.Text = prva_smena.Ime + " " + prva_smena.Prezime;
        }

        private void btnDrugaSmena_Click(object sender, EventArgs e)
        {
            druga_smena = operateri[lbOperateri.SelectedIndex];
            labDrugaSemna.Text = druga_smena.Ime + " " + druga_smena.Prezime;
        }

        private void btnTrecaSmena_Click(object sender, EventArgs e)
        {
            treca_smena = operateri[lbOperateri.SelectedIndex];
            labTrecaSmena.Text = treca_smena.Ime + " " + treca_smena.Prezime;
        }

        private void btnDodajNedelju_Click(object sender, EventArgs e)
        {
            if(prva_smena == null || druga_smena == null || treca_smena == null)
            {
                MessageBox.Show("Morate odabrati sve operatere");
                return;
            }

            try
            {
                ISession s = DataLayer.GetSession();

                Nedelja n = new Nedelja();

                n.Kontroler = kontrolor;
                n.Prva_smena = prva_smena;
                n.Druga_smena = druga_smena;
                n.Treca_smena = treca_smena;
                n.Pocetak_nedelje = new DateTime(dtpPocetakNedelje.Value.Year, dtpPocetakNedelje.Value.Month, dtpPocetakNedelje.Value.Day, 00, 00, 00);

                s.Save(n);
                s.Flush();
                s.Close();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpPocetakNedelje_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = dtpPocetakNedelje.Value;
            DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek + 1);
            DateTime pocetakNedelje = new DateTime(startOfWeek.Year, startOfWeek.Month, startOfWeek.Day, 00, 00, 00);

            dtpPocetakNedelje.Value = pocetakNedelje;
        }
    }
}
