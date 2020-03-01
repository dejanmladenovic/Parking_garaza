using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()
        {
            Table("OSOBA");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.OSOBA_ID_SEQ");

            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.Jmbg).Column("JMBG");
        }
    }
}
