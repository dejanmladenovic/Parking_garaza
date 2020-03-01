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
    public partial class IzmenaPodatakaOKartici : Form, Garaza.Interfaces.SelectionForm
    {
        private Parking novParking;
        private Glavna glavnaForma;
        private PretplatnaKartica kartica;
        private IList<Vozilo> vozila;
        private Korisnik korisnik;
        private IList<Rezervacija> rezervacije;
        public IzmenaPodatakaOKartici()
        {
            InitializeComponent();
            dtpVaziDoRez.CustomFormat = "dd/MM/yyyy";
            dtpVaziOdRez.CustomFormat = "dd/MM/yyyy";
        }

        private void btnPrikaziPodatke_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                kartica = s.Load<PretplatnaKartica>(int.Parse(txtIdKartice.Text));
                Osoba osoba = (Osoba)kartica.Korisnik;
                korisnik = s.Load<Korisnik>(osoba.Id);

                dtpVaziOd.Value = kartica.Vazi_od;
                dtpVaziDo.Value = kartica.Vazi_do;

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtJMBG.Text = korisnik.Jmbg;

                vozila = korisnik.Vozila;
                prikaziVozila(vozila);

                rezervacije = kartica.Rezervise;
                prikaziRezervacije(rezervacije);


                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void prikaziVozila(IList<Vozilo> vozila)
        {
            List<string> vozilaStr = new List<string>();
            foreach (Vozilo vozilo in vozila)
            {
                vozilaStr.Add(vozilo.Marka + " " + vozilo.Registarska_tablica + " " + vozilo.Tip);
            }
            lbVozila.DataSource = vozilaStr;
        }

        private void prikaziRezervacije(IList<Rezervacija> rezervacije)
        {
            List<string> rezervacijeStr = new List<string>();
            foreach (Rezervacija rezervacija in rezervacije)
            {
                rezervacijeStr.Add("Sprat: " + rezervacija.Parking.Sprat + " broj: " + rezervacija.Parking.Broj + " od " + rezervacija.Vazi_od.ToShortDateString() + " do " + rezervacija.Vazi_do.ToShortDateString());
            }
            lbRezPark.DataSource = rezervacijeStr;
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

        
        private String getCheckedCB()
        {
            if (rbTipA.Checked)
                return "A";
            if (rbTipB.Checked)
                return "B";
            return "C";
        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo novoVozilo = new Vozilo()
                {
                    Marka = txtMarka.Text,
                    Tip = getCheckedCB(),
                    Registarska_tablica = txtRegistarskeTablice.Text,
                    Korisnik = korisnik
                };

                korisnik.Vozila.Add(novoVozilo);

                s.Save(novoVozilo);
                s.Update(korisnik);
                s.Flush();
                s.Close();
                prikaziVozila(vozila);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOdaberiParking_Click(object sender, EventArgs e)
        {
            if (vozila.Count == 0)
            {
                MessageBox.Show("Niste selektovali ni jedno vozilo");
            }
            else
            {
                glavnaForma.nadjiOdgovarajuciParking(dtpVaziOd.Value, dtpVaziDo.Value, vozila[lbVozila.SelectedIndex].Tip);
                glavnaForma.BringToFront();
            }
        }

        private void IzmenaPodatakaOKartici_Load(object sender, EventArgs e)
        {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;
            txtJMBG.Enabled = false;
            btnDodajParkingURez.Enabled = false;
        }

        private void btnDodajParkingURez_Click(object sender, EventArgs e)
        {
            dtpVaziDoRez.MaxDate = dtpVaziDo.Value;
            try
            {
                ISession s = DataLayer.GetSession();
                Rezervacija rez = new Rezervacija()
                {
                    Vazi_od = dtpVaziOdRez.Value,
                    Vazi_do = dtpVaziDoRez.Value,
                    Kartica = kartica,
                    Parking = novParking
                };
                rezervacije.Add(rez);
                prikaziRezervacije(rezervacije);
                s.Save(rez);
                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnDodajParkingURez.Enabled = false;
        }

        private void btnIzmeniDatumVazenja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                kartica.Vazi_od = dtpVaziOd.Value;
                kartica.Vazi_do = dtpVaziDo.Value;

                s.Update(kartica);
                s.Flush();
                s.Close();
                dtpVaziOd.Value = kartica.Vazi_od;
                dtpVaziDo.Value = kartica.Vazi_do;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIzbrisiIzabranoVozilo_Click(object sender, EventArgs e)
        {
            if (vozila.Count == 0)
            {
                MessageBox.Show("Nema ni jendog vozila");
                return;
            }
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo vozilo = vozila[lbVozila.SelectedIndex];
                vozila.RemoveAt(lbVozila.SelectedIndex);

                s.Delete(vozilo);
                s.Flush();
                s.Close();
                prikaziVozila(vozila);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrisiRezervaciju_Click(object sender, EventArgs e)
        {
            
            if (rezervacije.Count == 0)
            {
                MessageBox.Show("Nema rezervacija!");
                return;
            }
            try
            {
                ISession s = DataLayer.GetSession();
                Rezervacija rez = rezervacije[lbRezPark.SelectedIndex];
                rezervacije.RemoveAt(lbRezPark.SelectedIndex);
                s.Delete(rez);
                s.Flush();
                s.Close();
                prikaziRezervacije(rezervacije);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IzmenaPodatakaOKartici_FormClosing(object sender, FormClosingEventArgs e)
        {
            glavnaForma.osveziParking();
            glavnaForma.biranjeForma = null;
        }
    }
}
