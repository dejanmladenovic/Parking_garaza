using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class Operater : Osoba
    {
        public virtual DateTime Datum_zaposljenja { get; set; }
        public virtual DateTime Datum_rodjenja { get; set; }
    }
}
