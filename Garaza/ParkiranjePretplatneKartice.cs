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
    public partial class ParkiranjePretplatneKartice : Form, Garaza.Interfaces.SelectionForm
    {
        private Glavna glavnaForma;
        private Parking izabranParking;
        PretplatnaKartica kartica;
        Korisnik korisnik;

        public ParkiranjePretplatneKartice()
        {
            InitializeComponent();
        }

        public void dodajGlavnuFormu(Glavna gf)
        {
            glavnaForma = gf;
            glavnaForma.biranjeForma = this;
        }

        public void setujParking(Parking p)
        {
            izabranParking = p;
            btnSave.Enabled = true;
        }

        private void btnLoadCard_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                kartica = s.Load<PretplatnaKartica>((int)numId.Value);

                if(kartica.Vazi_do < DateTime.Now)
                {
                    MessageBox.Show("Vaša kartica je istekla.");
                    this.Close();
                }


                korisnik = s.Load<Korisnik>(kartica.Korisnik.Id);

                if(korisnik.Vozila.Count == 0)
                {
                    MessageBox.Show("Nemate registovana vozila.");
                    this.Close();
                }

                int slobodniParkinzi = 0;

                for(int i=0; i < kartica.RezervisaniParkinzi.Count; i++)
                {
                    if(kartica.RezervisaniParkinzi[i].Vozilo == null)
                        slobodniParkinzi++;
                }

                if (slobodniParkinzi == 0)
                {
                    MessageBox.Show("Nemate slobodna mesta.");
                    this.Close();
                }

                if (korisnik.Vozila.Count == 1)
                {
                    kartica.RezervisaniParkinzi[0].Vozilo = korisnik.Vozila[0];
                    if(kartica.RezervisaniParkinzi.Count == 1)
                    {
                        s.Update(kartica.RezervisaniParkinzi[0]);
                        s.Close();
                        this.Close();
                    }
                    else
                    {
                        if (korisnik.Vozila[0].Tip == "A")
                        {
                            glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, true, false, false);
                        }
                        else if (korisnik.Vozila[0].Tip == "B")
                        {
                            glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, false, true, false);
                        }
                        else
                        {
                            glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, false, false, true);
                        }
                        glavnaForma.BringToFront();
                    }
                    
                }
                else
                {
                    listBox1.Items.Clear();
                    
                    for(int i=0; i < korisnik.Vozila.Count; i++)
                    {
                        bool vecPostoji = false;
                        for (int j = 0; j < kartica.RezervisaniParkinzi.Count; j++)
                        {
                            if(kartica.RezervisaniParkinzi[j].Vozilo != null)
                            {
                                if(korisnik.Vozila[i].Id == kartica.RezervisaniParkinzi[j].Vozilo.Id)
                                {
                                    vecPostoji = true;
                                    break;
                                }
                            }
                            
                        }
                        if (!vecPostoji)
                        {
                            listBox1.Items.Add(korisnik.Vozila[i].toString());
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int voziloIndex = listBox1.SelectedIndex;
            if(korisnik.Vozila[voziloIndex].Tip == "A")
            {
                glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, true, false, false);
            }
            else if(korisnik.Vozila[voziloIndex].Tip == "B")
            {
                glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, false, true, false);
            }
            else
            {
                glavnaForma.nadjiOdgovarajuciParking(kartica, korisnik, false, false, true);
            }
            glavnaForma.BringToFront();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                izabranParking.Vozilo = korisnik.Vozila[listBox1.SelectedIndex];
                s.Update(izabranParking);

                s.Flush();
                s.Close();
                
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParkiranjePretplatneKartice_FormClosing(object sender, FormClosingEventArgs e)
        {
            glavnaForma.osveziParking();
            glavnaForma.biranjeForma = null;
        }
    }
}
