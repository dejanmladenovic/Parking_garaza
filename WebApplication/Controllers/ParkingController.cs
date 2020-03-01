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
    public class ParkingController : ApiController
    {
        public IEnumerable<ParkingView> Get()
        {
            DataProvider p = new DataProvider();
            return p.vratiSlobodneParkinge();
        }

        public ParkingView Get(int sprat, int broj)
        {
            DataProvider p = new DataProvider();
            return p.vratiParking(sprat, broj);
        }

        public String Put(int sprat, int broj)
        {
            DataProvider p = new DataProvider();
            return p.azurirajParking(sprat, broj);
        }

        //dodavanje i brisanje parking mesta je izostavljeno
    }
}