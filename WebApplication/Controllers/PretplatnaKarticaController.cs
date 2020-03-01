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
    public class PretplatnaKarticaController : ApiController
    {
        public IEnumerable<PretplatnaKarticaView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSvePretplatneKartice();
        }

        public PretplatnaKarticaView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiPretplatnuKarticu(id);
        }

        public String Put([FromBody]PretplatnaKartica k)
        {
            DataProvider p = new DataProvider();
            return p.azurirajPretplatnuKarticu(k);
        }

        public String Post([FromBody]PretplatnaKartica k)
        {
            DataProvider p = new DataProvider();
            return p.dodajPretplatnuKarticu(k);
        }

        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiPretplatnuKarticu(id);
        }
    }
}