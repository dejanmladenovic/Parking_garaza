using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class VoziloMapiranja : ClassMap<Vozilo>
    {
        public VoziloMapiranja()
        {
            Table("VOZILO");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.VOZILO_ID_SEQ");

            Map(x => x.Marka).Column("MARKA");
            Map(x => x.Tip).Column("TIP");
            Map(x => x.Registarska_tablica).Column("REGISTARSKA_TABLICA");

            References(x => x.Korisnik).Column("KORISNIK_ID");
        }
    }
}
