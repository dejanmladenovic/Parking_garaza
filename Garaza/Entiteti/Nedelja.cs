using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class Nedelja
    {
        public virtual int Id { get; set; }
        public virtual DateTime Pocetak_nedelje { get; set; }
        public virtual Osoba Kontroler { get; set; }
        public virtual Osoba Prva_smena { get; set; }
        public virtual Osoba Druga_smena { get; set; }
        public virtual Osoba Treca_smena { get; set; }
    }
}
