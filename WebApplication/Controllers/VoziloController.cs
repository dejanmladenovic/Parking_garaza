using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Garaza.DTOs;
using Garaza.Entiteti;
using Garaza;

namespace WebApplication.Controllers
{
    public class VoziloController : ApiController
    {
        public IEnumerable<VoziloView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSvaVozila();
        }

        public VoziloView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiVozilo(id);
        }

        public String Post([FromBody]Vozilo v)
        {
            DataProvider p = new DataProvider();
            return p.dodajVozilo(v);
        }

        public String Put([FromBody]Vozilo v)
        {
            DataProvider p = new DataProvider();
            return p.azurirajVozilo(v);
        }

        public String Delete([FromBody]int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiVozilo(id);
        }
    }
}
