using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class OperaterView : OsobaView
    {
        public virtual DateTime Datum_zaposljenja { get; set; }
        public virtual DateTime Datum_rodjenja { get; set; }

        public OperaterView(Operater o) : base(o)
        {
            Datum_zaposljenja = o.Datum_zaposljenja;
            Datum_rodjenja = o.Datum_rodjenja;

        }
    }
}
