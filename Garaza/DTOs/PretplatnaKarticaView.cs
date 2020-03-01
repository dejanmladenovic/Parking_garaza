using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    public class PretplatnaKarticaView
    {
        public virtual DateTime Vazi_od { get; set; }
        public virtual DateTime Vazi_do { get; set; }
        public virtual OsobaView Korisnik { get; set; }
        
        public virtual IList<RezervacijaView> Rezervise { get; set; }

        public PretplatnaKarticaView( PretplatnaKartica k)
        {
            Rezervise = new List<RezervacijaView>();

            Vazi_od = k.Vazi_od;
            Vazi_do = k.Vazi_do;
            Korisnik = new OsobaView(k.Korisnik);
            foreach(Rezervacija r in k.Rezervise)
            {
                Rezervise.Add(new RezervacijaView(r));
            }
        }
    }
}
