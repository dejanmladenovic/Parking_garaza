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
    public class NedeljaController : ApiController
    {
        public IEnumerable<NedeljaView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSveNedelje();
        }

        public NedeljaView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiNedelju(id);
        }

        public String Post([FromBody]DateTime pocetakNedelje)
        {
            DataProvider p = new DataProvider();
            return p.dodajNedelju(pocetakNedelje);
        }

        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiNedelju(id);
        }
        public String Put(int id)
        {
            DataProvider p = new DataProvider();
            return p.azurirajNedelju(id);
        }

    }
}