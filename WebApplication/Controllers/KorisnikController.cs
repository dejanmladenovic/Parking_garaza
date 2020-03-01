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
    public class KorisnikController : ApiController
    {
        public IEnumerable<KorisnikView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSveKorisnike();
        }

        public KorisnikView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiKorisnika(id);
        }

        public String Post([FromBody]Korisnik k)
        {
            DataProvider p = new DataProvider();
            return p.dodajKorisnika(k);
        }
        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiKorisnika(id);
        }
        public String Put([FromBody]Korisnik k)
        {
            DataProvider p = new DataProvider();
            return p.azurirajKorisnika(k);
        }
    }
}