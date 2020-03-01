using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public class Rezervacija
    {
        public virtual int Id { get; set; }
        public virtual DateTime Vazi_od { get; set; }
        public virtual DateTime Vazi_do { get; set; }
        public virtual Parking Parking { get; set; }
        public virtual PretplatnaKartica Kartica { get; set; }

    }
}
