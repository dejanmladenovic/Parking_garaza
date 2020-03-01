using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garaza.Entiteti;
using FluentNHibernate.Mapping;

namespace Garaza.Mapiranja
{
    public class ParkingMapiranja : ClassMap<Parking>
    {
        public ParkingMapiranja()
        {
            Table("PARKING");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S16238.PARKING_ID_SEQ");

            Map(x => x.Sprat).Column("SPRAT");
            Map(x => x.Broj).Column("BROJ");
            Map(x => x.Flag_A).Column("A_FLAG");
            Map(x => x.Flag_B).Column("B_FLAG");
            Map(x => x.Flag_C).Column("C_FLAG");

            References(x => x.Vozilo).Column("VOZILO_ID");

            HasManyToMany(x => x.KarticeRezervacija)
                .Table("REZERVACIJA")
                .ParentKeyColumn("PARKING_ID")
                .ChildKeyColumn("KARTICA_ID")
                .Cascade.All();
            HasMany(x => x.Rezervacije).KeyColumn("PARKING_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
