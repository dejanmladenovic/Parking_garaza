using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    class PretplatnaKarticaMapiranja : ClassMap<PretplatnaKartica>
    {
        public PretplatnaKarticaMapiranja()
        {
            Table("PRETPLATNA_KARTICA");
            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.PRETPLATNA_KARTICA_ID_SEQ");

            Map(x => x.Vazi_od, "VAZI_OD");
            Map(x => x.Vazi_do, "VAZI_DO");

            References(x => x.Korisnik).Column("KORISNIK_ID");

            HasManyToMany(x => x.RezervisaniParkinzi)
                .Table("REZERVACIJA")
                .ParentKeyColumn("KARTICA_ID")
                .ChildKeyColumn("PARKING_ID")
                .Inverse()
                .Cascade.All();
            HasMany(x => x.Rezervise).KeyColumn("KARTICA_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
