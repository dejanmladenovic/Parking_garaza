using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    class RezervacijaMapiranja : ClassMap<Rezervacija>
    {
        public RezervacijaMapiranja()
        {
            Table("REZERVACIJA");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.REZERVACIJA_ID_SEQ");

            Map(x => x.Vazi_od, "VAZI_OD");
            Map(x => x.Vazi_do, "VAZI_DO");

            References(x => x.Parking).Column("PARKING_ID");
            References(x => x.Kartica).Column("KARTICA_ID");
        }
    }
}
