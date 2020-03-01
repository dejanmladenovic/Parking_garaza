using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    public class ParkingView
    {
        public virtual int Sprat { get; set; }
        public virtual int Broj { get; set; }
        public virtual VoziloView Vozilo { get; set; }
        public virtual bool Flag_A { get; set; }
        public virtual bool Flag_B { get; set; }
        public virtual bool Flag_C { get; set; }

        public ParkingView(Parking p)
        {
            Sprat = p.Sprat;
            Broj = p.Broj;
            if (p.Vozilo != null)
                Vozilo = new VoziloView(p.Vozilo);
            Flag_A = p.Flag_A;
            Flag_B = p.Flag_B;
            Flag_C = p.Flag_C;
        }
    }
}
