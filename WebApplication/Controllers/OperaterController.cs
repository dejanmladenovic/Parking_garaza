using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Garaza.DTOs;
using Garaza.Entiteti;
using Garaza;

namespace WebApplication.Controllers
{
    public class OperaterController : ApiController
    {
        public IEnumerable<OperaterView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSveOperatere();
        }

        public OperaterView Get(int id)
        {
            DataProvider p = new DataProvider();
            return p.vratiOperatera(id);
        }

        public String Post([FromBody]Operater o)
        {
            DataProvider p = new DataProvider();
            return p.dodajOperatera(o);
        }
        public String Delete(int id)
        {
            DataProvider p = new DataProvider();
            return p.izbrisiOperatera(id);
        }
        public String Put([FromBody]Operater o)
        {
            DataProvider p = new DataProvider();
            return p.azurirajOperatera(o);
        }
    }
}