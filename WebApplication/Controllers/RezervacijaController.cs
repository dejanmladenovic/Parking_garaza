using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Garaza.DTOs;
using Garaza;
using Garaza.Entiteti;

namespace WebApplication.Controllers
{
    public class RezervacijaController : ApiController
    {
        public IEnumerable<RezervacijaView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSveRezervacije();
        }

        public RezervacijaView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiRezervaciju(id);
        }

        public String Post([FromBody]Rezervacija r)
        {
            DataProvider p = new DataProvider();
            return p.dodajRezervaciju(r);
        }
        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiRezervaciju(id);
        }
        public String Put([FromBody]Rezervacija r)
        {
            DataProvider p = new DataProvider();
            return p.azurirajRezervaciju(r);
        }
    }
}