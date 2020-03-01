using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class Korisnik : Osoba
    {
        public virtual DateTime Datum_registracije { get; set; }
        public virtual IList<Vozilo> Vozila { get; set; }

        public Korisnik()
        {
            Vozila = new List<Vozilo>();
        }
    }
}
