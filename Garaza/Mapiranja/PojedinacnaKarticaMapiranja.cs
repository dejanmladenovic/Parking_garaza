using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class PojedinacnaKarticaMapiranja : ClassMap<PojedinacnaKartica>
    {
        public PojedinacnaKarticaMapiranja()
        {
            Table("POJEDINACNA_KARTICA");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.POJEDINACNA_KARTICA_ID_SEQ");

            Map(x => x.Vazi_od, "VAZI_OD");
            Map(x => x.Vazi_do, "VAZI_DO");
            Map(x => x.Vreme_napustanja, "VREME_NAPUSTANJA");

            References(x => x.Vozilo).Column("VOZILO_ID");
            References(x => x.Parking).Column("PARKING_ID");
            References(x => x.Operater).Column("OPERATER_ID");
        }
    }
}
