using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class KorisnikMapiranja : SubclassMap<Korisnik>
    {
        public KorisnikMapiranja()
        {
            Table("KORISNIK");

            KeyColumn("OSOBA_ID");
            Map(x => x.Datum_registracije).Column("DATUM_REGISTRACIJE");
            HasMany(x => x.Vozila).KeyColumn("KORISNIK_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
