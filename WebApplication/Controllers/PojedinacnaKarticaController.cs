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
    public class PojedinacnaKarticaController : ApiController
    {
        public IEnumerable<PojedinacnaKarticaView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSvePojedinacneKartice();
        }

        public PojedinacnaKarticaView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiPojedinacnuKarticu(id);
        }

        public String Post([FromBody]String vaziDoDate)
        {
            DataProvider p = new DataProvider();
            return p.dodajPojedinacnuKarticu(DateTime.ParseExact(vaziDoDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
        }

        public String Put(int id)
        {
            DataProvider p = new DataProvider();
            return p.azurirajPojedinacnuKarticu(id);
        }

        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiPojedinacnuKarticu(id);
        }
    }
}