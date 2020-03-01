using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garaza.Entiteti
{
    public abstract class Osoba
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Jmbg { get; set; }

        //korisnik
        //public virtual DateTime datum_registracije { get; set; }
        //public virtual List<Vozilo> vozila { get; set; }

        //operater
        //public virtual DateTime datum_zaposljenja { get; set; }


    }
}
