using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class VoziloView
    {
        public virtual string Marka { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Registarska_tablica { get; set; }
        public virtual OsobaView Korisnik { get; set; }

        public VoziloView(Vozilo v)
        {
            Marka = v.Marka;
            Tip = v.Tip;
            Registarska_tablica = v.Registarska_tablica;
            if(v.Korisnik != null)
                Korisnik = new OsobaView(v.Korisnik);
        }
    }
}
