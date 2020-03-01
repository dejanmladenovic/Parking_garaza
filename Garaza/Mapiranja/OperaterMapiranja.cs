using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class OperaterMapiranja : SubclassMap<Operater>
    {
        public OperaterMapiranja()
        {
            Table("OPERATER");

            KeyColumn("OSOBA_ID");

            Map(x => x.Datum_rodjenja).Column("DATUM_RODJENJA");
            Map(x => x.Datum_zaposljenja).Column("DATUM_ZAPOSLJENJA");
        }
        
    }
}
