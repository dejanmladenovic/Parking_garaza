using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class PretplatnaKartica
    {
        public virtual int Id { get; set; }
        public virtual DateTime Vazi_od { get; set; }
        public virtual DateTime Vazi_do { get; set; }
        public virtual Osoba Korisnik { get; set; }

        public virtual IList<Parking> RezervisaniParkinzi { get; set; }
        public virtual IList<Rezervacija> Rezervise { get; set; }

        public PretplatnaKartica()
        {
            RezervisaniParkinzi = new List<Parking>();
            Rezervise = new List<Rezervacija>();
        }
    }
}
