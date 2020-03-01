using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class Vozilo 
    {
        public virtual int Id { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Registarska_tablica { get; set; }
        public virtual Osoba Korisnik { get; set; }

        public virtual string toString()
        {
            return Tip + "  " + Marka + "  " + Registarska_tablica;
        }
    }
}
