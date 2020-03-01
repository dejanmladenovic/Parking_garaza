using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class PojedinacnaKarticaView
    {
        public virtual DateTime Vazi_od { get; set; }
        public virtual DateTime Vazi_do { get; set; }
        public virtual DateTime Vreme_napustanja { get; set; }
        public virtual VoziloView Vozilo { get; set; }
        public virtual ParkingView Parking { get; set; }
        public virtual OsobaView Operater { get; set; }

        public PojedinacnaKarticaView(PojedinacnaKartica k)
        {
            Vazi_od = k.Vazi_od;
            Vazi_do = k.Vazi_do;
            Vreme_napustanja = k.Vreme_napustanja;
            Vozilo = new VoziloView(k.Vozilo);
            Parking = new ParkingView(k.Parking);
            Operater = new OsobaView(k.Operater);
        }
    }


}
