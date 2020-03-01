using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    class NedeljaMapiranja : ClassMap<Nedelja>
    {
        public NedeljaMapiranja()
        {
            Table("NEDELJA");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.NEDELJA_ID_SEQ");

            Map(x => x.Pocetak_nedelje, "POCETAK_NEDELJE");

            References(x => x.Kontroler).Column("KONTROLER_ID");
            References(x => x.Prva_smena).Column("PRVA_SMENA_ID");
            References(x => x.Druga_smena).Column("DRUGA_SMENA_ID");
            References(x => x.Treca_smena).Column("TRECA_SMENA_ID");
        }
    }
}
