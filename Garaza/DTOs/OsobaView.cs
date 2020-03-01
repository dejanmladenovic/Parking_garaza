using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class OsobaView
    {
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Jmbg { get; set; }

        public OsobaView(Osoba o)
        {
            Ime = o.Ime;
            Prezime = o.Prezime;
            Jmbg = o.Jmbg;
        }
    }
}
