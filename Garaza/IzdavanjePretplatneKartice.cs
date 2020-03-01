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
    public partial class IzdavanjePretplatneKartice : Form, Garaza.Interfaces.SelectionForm
    {

        private Glavna glavnaForma;
        private List<Parking> RezervPark = new List<Parking>();
        private Parking novParking;
        private List<Vozilo> vozila = new List<Vozilo>();
        private List<DateTime> vaziOdRez = new List<DateTime>();
        private List<DateTime> vaziDoRez = new List<DateTime>();

        public IzdavanjePretplatneKartice()
        {
            InitializeComponent();
            dtpVaziDoRez.CustomFormat = "dd/MM/yyyy";
            dtpVaziOdRez.CustomFormat = "dd/MM/yyyy";
        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo v = new Vozilo()
                {
                    Marka = txtMarka.Text,
                    Tip = getCheckedCB(),
                    Registarska_tablica = txtRegistarskeTablice.Text
                };
                s.Save(v);
                this.vozila.Add(v);
                List<string> vozilaStr = new List<string>();
                foreach (Vozilo vozilo in this.vozila)
                {
                    vozilaStr.Add(vozilo.Marka + " " + vozilo.Registarska_tablica + " " + vozilo.Tip);
                }
                lbVozila.DataSource = vozilaStr;

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (vozila.Count > 0)
            {
                btnNadjiParking.Enabled = true;
            }
        }

        private void btnDodajParkingURez_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Parking park = s.Load<Parking>(int.Parse(txtParkingId.Text));
                dtpVaziDoRez.MaxDate = dtpVaziDo.Value;
                RezervPark.Add(novParking);
                vaziOdRez.Add(dtpVaziOdRez.Value);
                vaziDoRez.Add(dtpVaziDoRez.Value);
                List<string> parkStr = new List<string>();
                int i = 0;
                foreach (Parking parking in RezervPark)
                {
                    parkStr.Add("Sprat: " + parking.Sprat + " Broj: " + parking.Broj + " od: " + vaziOdRez[i].ToShortDateString() + "Do " + vaziDoRez[i].ToShortDateString());
                    i++;
                }
                lbRezPark.DataSource = parkStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (RezervPark.Count != 0 && vozila.Count != 0)
            {
                btnIzdajPretplatnuKarticu.Enabled = true;
            }
            btnDodajParkingURez.Enabled = false;
        }

        private void btnIzdajPretplatnuKarticu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = new Korisnik()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Jmbg = txtJMBG.Text,
                    Datum_registracije = DateTime.Now
                };

                foreach (Vozilo v in this.vozila)
                {
                    k.Vozila.Add(v);
                    v.Korisnik = k;
                }

                PretplatnaKartica pretKart = new PretplatnaKartica()
                {
                    Vazi_od = dtpVaziOd.Value,
                    Vazi_do = dtpVaziDo.Value,
                    Korisnik = k
                };

                s.Save(k);
                s.Save(pretKart);
                dtpVaziDoRez.MaxDate = pretKart.Vazi_do;
                int i = 0;
                foreach (Parking park in this.RezervPark)
                {
                    Rezervacija rez = new Rezervacija()
                    {
                        Vazi_od = vaziOdRez[i],
                        Vazi_do = vaziDoRez[i],
                        Kartica = pretKart,
                        Parking = park
                    };
                    s.Save(rez);
                    i++;
                }



                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        public void dodajGlavnuFormu(Glavna gf)
        {
            glavnaForma = gf;
            glavnaForma.biranjeForma = this;
        }

        public void setujParking(Parking p)
        {
            novParking = p;
            btnDodajParkingURez.Enabled = true;
        }

        private void btnNadjiParking_Click(object sender, EventArgs e)
        {
            glavnaForma.nadjiOdgovarajuciParking(dtpVaziOd.Value, dtpVaziDo.Value, vozila[lbVozila.SelectedIndex].Tip);
            glavnaForma.BringToFront();
        }
        private String getCheckedCB()
        {
            if (rbTipA.Checked)
                return "A";
            if (rbTipB.Checked)
                return "B";
            return "C";
        }

        private void IzdavanjePretplatneKartice_Load(object sender, EventArgs e)
        {
            btnNadjiParking.Enabled = false;
            btnDodajParkingURez.Enabled = false;
            btnIzdajPretplatnuKarticu.Enabled = false;
        }

        private void IzdavanjePretplatneKartice_FormClosing(object sender, FormClosingEventArgs e)
        {
            glavnaForma.osveziParking();
            glavnaForma.biranjeForma = null;
        }
    }
}
