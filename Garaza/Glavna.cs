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
using Garaza.CustomComponents;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Garaza
{
    public partial class Glavna : Form
    {

        List<TableLayoutPanel> TLPparkingMesta;
        List<ParkingButton> ParkingDugmici;
        public Garaza.Interfaces.SelectionForm biranjeForma;

        System.Drawing.Color BojaSlobodan = System.Drawing.Color.YellowGreen;
        System.Drawing.Color BojaRezervisan = System.Drawing.Color.Yellow;
        System.Drawing.Color BojaParkiran = System.Drawing.Color.Orange;
        System.Drawing.Color OdabranParking = System.Drawing.Color.LightBlue;

        public Glavna()
        {
            InitializeComponent();
            

            try { 
                ISession s = DataLayer.GetSession();
                IList<Parking> parkingMesta = s.QueryOver<Parking>()
                                        .OrderBy(p => p.Sprat).Asc
                                        .OrderBy(p => p.Broj).Asc
                                        .List<Parking>()
                                        ;
                ParkingDugmici = new List<ParkingButton>();

                TLPparkingMesta = new List<TableLayoutPanel>();

                TLPparkingMesta.Add((TableLayoutPanel)TBLprviSprat.GetControlFromPosition(0, 0));
                TLPparkingMesta.Add((TableLayoutPanel)TBLprviSprat.GetControlFromPosition(0, 2));
                TLPparkingMesta.Add((TableLayoutPanel)TBLprviSprat.GetControlFromPosition(0, 3));
                TLPparkingMesta.Add((TableLayoutPanel)TBLprviSprat.GetControlFromPosition(0, 5));

                TLPparkingMesta.Add((TableLayoutPanel)TLPdrugiSprat.GetControlFromPosition(0, 0));
                TLPparkingMesta.Add((TableLayoutPanel)TLPdrugiSprat.GetControlFromPosition(0, 2));
                TLPparkingMesta.Add((TableLayoutPanel)TLPdrugiSprat.GetControlFromPosition(0, 3));
                TLPparkingMesta.Add((TableLayoutPanel)TLPdrugiSprat.GetControlFromPosition(0, 5));

                ParkingButton trDugme;
                int k = 0;
                for (int i = 0; i < TLPparkingMesta.Count; i++)
                {
                    for (int j = 0; j < TLPparkingMesta[i].ColumnCount; j++)
                    {
                        trDugme = new ParkingButton(parkingMesta[k++]);
                        ParkingDugmici.Add(trDugme);
                        TLPparkingMesta[i].Controls.Add(trDugme);
                        trDugme.Click += new EventHandler(selectParking);
                    }
                }

                obeleziRezervisaneParkinge();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void obeleziRezervisaneParkinge()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Rezervacija> vazeceRezervacije = s.QueryOver<Rezervacija>()
                                                        .Where(r => r.Vazi_od < DateTime.Now)
                                                        .Where(r => r.Vazi_do > DateTime.Now)
                                                        .List();

                Parking trenutniParking;
                for (int i = 0; i < vazeceRezervacije.Count; i++)
                {
                    trenutniParking = vazeceRezervacije[i].Parking;
                    ParkingDugmici[(trenutniParking.Sprat - 1) * 32 + trenutniParking.Broj - 1].FlatAppearance.BorderColor = BojaRezervisan;
                    ParkingDugmici[(trenutniParking.Sprat - 1) * 32 + trenutniParking.Broj - 1].FlatAppearance.BorderSize = 3;
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void osveziParking()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Parking> parkingMesta = s.QueryOver<Parking>()
                                        .OrderBy(p => p.Sprat).Asc
                                        .OrderBy(p => p.Broj).Asc
                                        .List<Parking>();
                for(int i=0; i < ParkingDugmici.Count; i++)
                {
                    ParkingDugmici[i].dodajParking(parkingMesta[i]);
                }

                IList<Rezervacija> vazeceRezervacije = s.QueryOver<Rezervacija>()
                                                        .Where(r => r.Vazi_od < DateTime.Now)
                                                        .Where(r => r.Vazi_do > DateTime.Now)
                                                        .List();

                Parking trenutniParking;
                for (int i = 0; i < vazeceRezervacije.Count; i++)
                {
                    trenutniParking = vazeceRezervacije[i].Parking;
                    ParkingDugmici[(trenutniParking.Sprat - 1) * 32 + trenutniParking.Broj - 1].FlatAppearance.BorderColor = BojaRezervisan;
                }

                obeleziRezervisaneParkinge();

                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public void nadjiOdgovarajuciParking(DateTime vremeOd, DateTime vremeDo, String tipVozila)
        {
            try
            {
                osveziParking();

                String strOd = vremeOd.ToString("dd'-'MM'-'yyyy' 'hh':'mm");
                String strDo = vremeDo.ToString("dd'-'MM'-'yyyy' 'hh':'mm");

                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateSQLQuery("SELECT PARKING.SPRAT, PARKING.BROJ FROM PARKING "
                                                + "WHERE VOZILO_ID IS NULL AND " + tipVozila + "_FLAG = 1 "
                                                + "MINUS "
                                                + "SELECT PARKING.SPRAT, PARKING.BROJ FROM PARKING INNER JOIN REZERVACIJA ON PARKING.ID = REZERVACIJA.PARKING_ID "
                                                //+ " WHERE ? <= REZERVACIJA.VAZI_DO AND ? >= REZERVACIJA.VAZI_OD "
                                                + " WHERE TO_DATE('"+strOd+"', 'DD-MM-YYYY HH24:MI') <= REZERVACIJA.VAZI_DO AND TO_DATE('"+strDo+"', 'DD-MM-YYYY HH24:MI') >= REZERVACIJA.VAZI_OD "
                                                + "ORDER BY SPRAT, BROJ");

                

                IList<Object[]> result = q.List<Object[]>();

                if(result.Count == 0)
                {
                    MessageBox.Show("Ne postoji parking za rezervaciju");
                    s.Close();
                    return;
                }

                foreach (Object[] obj in result)
                {
                    ParkingDugmici[((Int16)obj[0] - 1) * 32 + (Int16)obj[1] - 1].BackColor = BojaSlobodan;
                }

                

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void nadjiOdgovarajuciParking(PretplatnaKartica kartica, Korisnik korisnik, bool kategorijaA, bool kategorijaB, bool kategorijaC)
        {
          
            Parking trParking;
            for(int i=0; i < kartica.RezervisaniParkinzi.Count; i++)
            {
                trParking = kartica.RezervisaniParkinzi[i];

                if (trParking.Flag_A == kategorijaA && trParking.Flag_B == kategorijaB && trParking.Flag_C == kategorijaC && trParking.Vozilo == null)
                {
                    ParkingDugmici[(trParking.Sprat - 1) * 32 + trParking.Broj - 1].BackColor = BojaSlobodan;
                }
            }
            
        }

        public void nadjiZauzeteParkinge(PretplatnaKartica kartica)
        {
            Parking trParking;
            for(int i=0; i < kartica.RezervisaniParkinzi.Count; i++)
            {
                trParking = kartica.RezervisaniParkinzi[i];
                if (trParking.Vozilo != null)
                {
                    ParkingDugmici[(trParking.Sprat - 1) * 32 + trParking.Broj - 1].BackColor = BojaParkiran;
                }
            }
        }




        private void selectParking(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                return;
            }
            else
            {
                ParkingButton dugme = (ParkingButton)sender;
                if (dugme.BackColor == BojaSlobodan || dugme.BackColor == BojaParkiran)
                {
                    dugme.BackColor = OdabranParking;
                    this.biranjeForma.setujParking(dugme.Parking);
                    Form forma = (Form)biranjeForma;
                    forma.BringToFront();
                }
            }
        }

        private void btnPojedinacnaKartica_Click(object sender, EventArgs e)
        {
            if(biranjeForma == null)
            {
                PojedinacnaKaricaForma forma = new PojedinacnaKaricaForma();
                forma.dodajGlavnuFormu(this);
                forma.Show();
            }
        }

        private void btnNapustanjeVozila_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                IzmenaPojedKartice form = new IzmenaPojedKartice();
                form.ShowDialog();
                osveziParking();
            }
                
        }

        private void btnParkirajPretplatnika_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                ParkiranjePretplatneKartice forma = new ParkiranjePretplatneKartice();
                forma.dodajGlavnuFormu(this);
                forma.Show();
            }
        }

        private void btnIsparkirajPretplatnika_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                NapustanjePretplatneKartice forma = new NapustanjePretplatneKartice();
                forma.dodajGlavnuFormu(this);
                forma.Show();
            }
        }

        private void btnNovaPretplatna_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                IzdavanjePretplatneKartice forma = new IzdavanjePretplatneKartice();
                forma.dodajGlavnuFormu(this);
                forma.Show();
            }
        }

        private void btnIzmenaPretplatne_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                IzmenaPodatakaOKartici forma = new IzmenaPodatakaOKartici();
                forma.dodajGlavnuFormu(this);
                forma.Show();
            }
        }

        private void btnNedelja_Click(object sender, EventArgs e)
        {
            if (biranjeForma == null)
            {
                OrganizovanjeNedelje forma = new OrganizovanjeNedelje();
                forma.ShowDialog();
            }
        }
    }
}
