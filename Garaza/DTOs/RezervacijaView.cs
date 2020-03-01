using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    public class RezervacijaView
    {
        public virtual DateTime Vazi_od { get; set; }
        public virtual DateTime Vazi_do { get; set; }
        public virtual ParkingView Parking { get; set; }

        public RezervacijaView(Rezervacija r)
        {
            Vazi_do = r.Vazi_do;
            Vazi_od = r.Vazi_od;
            Parking = new ParkingView(r.Parking);
        }
    }
}
