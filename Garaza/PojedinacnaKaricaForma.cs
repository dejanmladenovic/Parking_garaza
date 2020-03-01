using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Garaza.Entiteti;
using NHibernate;

namespace Garaza
{
    public partial class PojedinacnaKaricaForma : Form, Garaza.Interfaces.SelectionForm
    {
        private Glavna glavnaForma;
        private Parking izabranParking;
        private Vozilo vozilo;

        public PojedinacnaKaricaForma()
        {
            InitializeComponent();
            dtpDatum.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        public PojedinacnaKaricaForma(Glavna gf)
        {
            dodajGlavnuFormu(gf);
            InitializeComponent();
        }

        public void dodajGlavnuFormu(Glavna glavnaForma)
        {
            this.glavnaForma = glavnaForma;
            glavnaForma.biranjeForma = this;
        }

        public void setujParking(Parking p)
        {
            izabranParking = p;
            btnSave.Enabled = true;
        }

        private void PojedinacnaKaricaForma_FormClosing(object sender, FormClosingEventArgs e)
        {
            glavnaForma.osveziParking();
            glavnaForma.biranjeForma = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(izabranParking == null)
            {
                MessageBox.Show("Morate odabrati parking.");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbTablica.Text))
            {
                MessageBox.Show("Morate uneti registarsku tablicu vozila.");
                return;
            }
            if(izabranParking == null)
            {
                MessageBox.Show("Morate odabrati parking.");
                return;
            }
            try
            {
                ISession s = DataLayer.GetSession();

                Osoba op;
                DateTime now = DateTime.Now;
                DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek + 1);
                DateTime pocetakNedelje = new DateTime(startOfWeek.Year, startOfWeek.Month, startOfWeek.Day, 00, 00, 00);
                Nedelja ned = s.QueryOver<Nedelja>()
                                     .Where(p => p.Pocetak_nedelje == pocetakNedelje)
                                     .SingleOrDefault();


                TimeSpan trenutnoVreme = DateTime.Now.TimeOfDay;
                TimeSpan prvaSmena = new TimeSpan(0, 0, 0); 
                TimeSpan drugaSmena = new TimeSpan(8, 0, 0);   
                TimeSpan trecaSmena = new TimeSpan(16, 0, 0); 
                if (trenutnoVreme >= prvaSmena && trenutnoVreme < drugaSmena)
                {
                    op = (Osoba)ned.Prva_smena;
                }
                else if(trenutnoVreme >= drugaSmena && trenutnoVreme < trecaSmena)
                {
                    op = (Osoba)ned.Druga_smena;
                }
                else
                {
                    op = (Osoba)ned.Treca_smena;
                }
                Operater operater = s.Load<Operater>(op.Id);

                Vozilo v = new Vozilo()
                {
                    Tip = getCheckedCB(),
                    Registarska_tablica = tbTablica.Text
                };


                PojedinacnaKartica kartica = new PojedinacnaKartica()
                {
                    Parking = izabranParking,
                    Vazi_od = DateTime.Now,
                    Vazi_do = dtpDatum.Value,
                    Vozilo = v,
                    Operater = operater
                };

                izabranParking.Vozilo = v;

                s.Update(izabranParking);
                s.Save(v);
                s.Save(kartica);

                s.Flush();
                s.Close();

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private String getCheckedCB()
        {
            if (rbTipA.Checked)
                return "A";
            if (rbTipB.Checked)
                return "B";
            return "C";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            glavnaForma.nadjiOdgovarajuciParking(DateTime.Now, dtpDatum.Value, getCheckedCB());
            glavnaForma.BringToFront();
        }
    }
}
