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
    public partial class IzmenaPojedKartice : Form
    {
        private PojedinacnaKartica kartica;
        public IzmenaPojedKartice()
        {
            InitializeComponent();
        }

        private void btnPrikaziPodatke_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                kartica = s.Load<PojedinacnaKartica>((int)numId.Value);

                labVaziOd.Text = kartica.Vazi_od.ToString();
                labVaziDo.Text = kartica.Vazi_do.ToShortDateString();
                labRegisTabl.Text = kartica.Vozilo.Registarska_tablica;
                labSprat.Text = kartica.Parking.Sprat.ToString();
                labBroj.Text = kartica.Parking.Broj.ToString();

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOslobodParking_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                kartica = s.Load<PojedinacnaKartica>((int)numId.Value);

                kartica.Vreme_napustanja = DateTime.Now;
                kartica.Parking.Vozilo = null;

                s.Update(kartica);
                s.Update(kartica.Parking);
                s.Flush();
                s.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
