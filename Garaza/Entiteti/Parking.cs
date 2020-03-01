using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Garaza.Entiteti
{
    public class Parking
    {
        public virtual int Id { get; set; }
        public virtual int Sprat { get; set; }
        public virtual int Broj { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual bool Flag_A { get; set; }
        public virtual bool Flag_B { get; set; }
        public virtual bool Flag_C { get; set; }

        public virtual IList<PretplatnaKartica> KarticeRezervacija { get; set; }
        public virtual IList<Rezervacija> Rezervacije { get; set; }

        public Parking()
        {
            KarticeRezervacija = new List<PretplatnaKartica>();
            Rezervacije = new List<Rezervacija>();
        }

        public virtual String stampajLabelu()
        {
            String returnStr = "";

            switch (Sprat)
            {
                case 1:
                    returnStr += "I-";
                    break;
                case 2:
                    returnStr += "II-";
                    break;
                case 3:
                    returnStr += "III-";
                    break;
                case 4:
                    returnStr += "IV-";
                    break;
                case 5:
                    returnStr += "V-";
                    break;
            }
            return returnStr += Broj;
        }
    }
}

