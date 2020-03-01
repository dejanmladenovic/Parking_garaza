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
    public partial class NapustanjePretplatneKartice : Form, Garaza.Interfaces.SelectionForm
    {
        
        private Glavna glavnaForma;
        PretplatnaKartica kartica;


        public NapustanjePretplatneKartice()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                kartica = s.Load<PretplatnaKartica>((int)numId.Value);

                if (kartica.Vazi_do < DateTime.Now)
                {
                    MessageBox.Show("Vaša kartica je istekla.");
                    this.Close();
                }

                if(kartica.RezervisaniParkinzi.Count == 1)
                {
                    if(kartica.RezervisaniParkinzi[1].Vozilo == null)
                    {
                        MessageBox.Show("Nemate parkirana vozila.");
                        this.Close();
                    }
                    else
                    {
                        kartica.RezervisaniParkinzi[1].Vozilo = null;
                        s.Update(kartica.RezervisaniParkinzi[1]);
                        s.Flush();
                        s.Close();
                        this.Close();
                    }
                }
                else
                {
                    int zauzetaMesta = 0;
                    int zauzetoMesto = 0;
                    for(int i = 0; i < kartica.RezervisaniParkinzi.Count; i++)
                    {
                        if (kartica.RezervisaniParkinzi[i].Vozilo != null)
                        {
                            zauzetaMesta++;
                            zauzetoMesto = i;
                        }
                    }
                    if(zauzetaMesta == 0)
                    {
                        MessageBox.Show("Nemate parkirana vozila.");
                        this.Close();
                    }
                    else if(zauzetaMesta == 1)
                    {
                        kartica.RezervisaniParkinzi[zauzetoMesto].Vozilo = null;
                        s.Update(kartica.RezervisaniParkinzi[1]);
                        s.Flush();
                        s.Close();
                    }
                    else{
                        glavnaForma.nadjiZauzeteParkinge(kartica);
                        lblInfo.Visible = true;
                        glavnaForma.BringToFront();
                    }
                }
                

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dodajGlavnuFormu(Glavna gf)
        {
            glavnaForma = gf;
            glavnaForma.biranjeForma = this;
        }

        public void setujParking(Parking p)
        {
            try
            {
                Parking izabranParking = p;
                ISession s = DataLayer.GetSession();

                izabranParking.Vozilo = null;

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

        private void NapustanjePretplatneKartice_FormClosing(object sender, FormClosingEventArgs e)
        {
            glavnaForma.osveziParking();
            glavnaForma.biranjeForma = null;
        }
    }
}
