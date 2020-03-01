using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class KorisnikView : OsobaView
    {
        public virtual DateTime Datum_registracije { get; set; }
        public virtual List<VoziloView> Vozila { get; set; }


        public KorisnikView(Korisnik k) : base(k)
        {
            Vozila = new List<VoziloView>();
            Datum_registracije = k.Datum_registracije;
            foreach (Vozilo v in k.Vozila)    // ovde pravi neku gresku
            {
                Vozila.Add(new VoziloView(v));
            }
        }

    }
}
