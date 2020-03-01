using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Garaza.Entiteti;

namespace Garaza.CustomComponents
{
    public class ParkingButton : Button
    {
        //public Parking Parking;
        public Parking Parking;


        public ParkingButton()
        {
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 2;
        }

        public ParkingButton(Parking p)
        {
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 2;
            dodajParking(p);
        }

        public void dodajParking(Parking p)
        {
            Parking = p;




            if (p.Vozilo != null)
            {
                this.BackColor = System.Drawing.Color.Tomato;
            }
            else
            {
                this.BackColor = System.Drawing.Color.Transparent;

            }
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 1;
            this.Text = p.stampajLabelu();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ParkingButton
            // 
            this.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.FlatAppearance.BorderSize = 3;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.ResumeLayout(false);

        }
    }
        
}
