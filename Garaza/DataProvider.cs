using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Garaza.Entiteti;
using Garaza.DTOs;
using NHibernate;
using NHibernate.Linq;

namespace Garaza
{
    public class DataProvider
    {
        #region Vozila
        public IEnumerable<VoziloView> vratiSvaVozila()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<VoziloView> lista = new List<VoziloView>();
                foreach (Vozilo v in s.Query<Vozilo>().ToList())
                {
                    lista.Add(new VoziloView(v));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public VoziloView vratiVozilo(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo v = s.Get<Vozilo>(id);
                if (v != null)
                    return new VoziloView(v);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public String dodajVozilo(Vozilo v)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(v);

                s.Flush();
                s.Close();

                return "Uspesno dodato";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajVozilo(Vozilo v)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Update(v);

                s.Flush();
                s.Close();

                return "Uspesno azurirano";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String izbrisiVozilo(int  id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo v = new Vozilo() { Id = id };

                s.Delete(v);

                s.Flush();
                s.Close();

                return "Uspesno izbrisano";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        #endregion

        #region Operater

        public IEnumerable<OperaterView> vratiSveOperatere()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<OperaterView> lista = new List<OperaterView>();
                foreach (Operater o in s.Query<Operater>().ToList())
                {
                    lista.Add(new OperaterView(o));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public OperaterView vratiOperatera(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Operater o = s.Load<Operater>(id);
                if (o != null)
                {
                    s.Close();
                    return new OperaterView(o);
                }
                else
                {
                    s.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public String dodajOperatera(Operater o)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(o);
                s.Flush();
                s.Close();

                return "Uspesno";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String izbrisiOperatera(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Operater o = s.Load<Operater>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
                return "Uspesno uklonjen operater";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajOperatera(Operater o)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Update(o);
                s.Flush();
                s.Close();

                return "Uspesno azuriran";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }


        #endregion

        #region Parking

        public IEnumerable<ParkingView> vratiSlobodneParkinge()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<ParkingView> lista = new List<ParkingView>();
                foreach (Parking p in s.QueryOver<Parking>().Where(x => x.Vozilo == null).OrderBy(x => x.Sprat).Asc.OrderBy(x => x.Broj).Asc.List<Parking>())
                {
                    lista.Add(new ParkingView(p));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ParkingView vratiParking(int sprat, int broj)
        {
            ISession s = DataLayer.GetSession();
            ParkingView p = new ParkingView(s.QueryOver<Parking>().Where(x => x.Sprat == sprat && x.Broj == broj).SingleOrDefault());
            s.Close();
            return p;
        }

        public String azurirajParking(int sprat, int broj)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = s.QueryOver<Parking>().Where(x => x.Sprat == sprat && x.Broj == broj).SingleOrDefault();
                Vozilo v = new Vozilo() { Marka = "Fiat Punto", Registarska_tablica = "NI-1234", Tip = "B" };
                p.Vozilo = v;

                s.Save(v);
                s.Update(p);
                s.Flush();
                s.Close();

                return "Uspesno azuriran parking";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        
        #endregion

        #region Korisnik

        public IEnumerable<KorisnikView> vratiSveKorisnike()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<KorisnikView> lista = new List<KorisnikView>();
                foreach (Korisnik k in s.Query<Korisnik>().ToList())
                {
                    lista.Add(new KorisnikView(k));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public KorisnikView vratiKorisnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik k = s.Get<Korisnik>(id);
                KorisnikView v = new KorisnikView(k);
                s.Close();
                return v;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
                
        }

        public String dodajKorisnika(Korisnik k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(k);
                s.Flush();
                s.Close();

                return "Uspesno";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String izbrisiKorisnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik k = s.Load<Korisnik>(id);
                s.Delete(k);
                s.Flush();
                s.Close();
                return "Uspesno uklonjen korisnik";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajKorisnika(Korisnik k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Update(k);
                s.Flush();
                s.Close();

                return "Uspesno azuriran";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        #endregion

        #region Nedelje
        public IEnumerable<NedeljaView> vratiSveNedelje()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<NedeljaView> lista = new List<NedeljaView>();
                foreach (Nedelja n in s.Query<Nedelja>().ToList())
                {
                    lista.Add(new NedeljaView(n));
                }
                s.Close();
                return lista;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public NedeljaView vratiNedelju(int id)
        {
        try
            {
                ISession s = DataLayer.GetSession();
                Nedelja n = s.Get<Nedelja>(id);
                if (n != null)
                    return new NedeljaView(n);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public String dodajNedelju(DateTime p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Operater k = s.Get<Operater>(5);
                Operater o1 = s.Get<Operater>(5);
                Operater o2 = s.Get<Operater>(6);
                Operater o3 = s.Get<Operater>(7);

                Nedelja n = new Nedelja
                {
                    Pocetak_nedelje = p,
                    Kontroler = k,
                    Prva_smena = o1,
                    Druga_smena = o2,
                    Treca_smena = o3
                };
                s.Save(n);
                s.Flush();
                s.Close();

                return "Uspesno";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String izbrisiNedelju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Nedelja n = s.Load<Nedelja>(id);
                s.Delete(n);
                s.Flush();
                s.Close();
                return "Uspesno uklonjena nedelja";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajNedelju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Nedelja n = s.Get<Nedelja>(id);

                n.Kontroler = s.Get<Operater>(7);

                s.Update(n);
                s.Flush();
                s.Close();

                return "Uspesno azuriran";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        #endregion

        #region PojedinacnaKartica

        public IEnumerable<PojedinacnaKarticaView> vratiSvePojedinacneKartice()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<PojedinacnaKarticaView> lista = new List<PojedinacnaKarticaView>();
                foreach (PojedinacnaKartica k in s.Query<PojedinacnaKartica>().ToList())
                {
                    lista.Add(new PojedinacnaKarticaView(k));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public PojedinacnaKarticaView vratiPojedinacnuKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PojedinacnaKartica k = s.Get<PojedinacnaKartica>(id);
                if (k != null)
                    return new PojedinacnaKarticaView(k);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public String dodajPojedinacnuKarticu(DateTime vaziDo)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = new Vozilo() { Marka = "Audi", Registarska_tablica = "PK 027 22", Tip = "B" };

                PojedinacnaKartica k = new PojedinacnaKartica()
                {
                    Operater = s.Get<Operater>(5),
                    Parking = s.Get<Parking>(7),
                    Vazi_od = DateTime.Now,
                    Vozilo = v,
                    Vazi_do = vaziDo,
                };
                
                s.Save(v);
                s.Save(k);
                s.Flush();
                s.Close();

                return "Uspesno";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }


        public String izbrisiPojedinacnuKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PojedinacnaKartica k = s.Load<PojedinacnaKartica>(id);
                s.Delete(k);
                s.Flush();
                s.Close();
                return "Uspesno uklonjena kartica";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajPojedinacnuKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PojedinacnaKartica k = s.Load<PojedinacnaKartica>(id);

                k.Vreme_napustanja = DateTime.Now;
                

                s.Update(k);
                s.Flush();
                s.Close();

                return "Uspesno azurirana kartica sa vremenom napustanja";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        #endregion

        #region PretplanaKartica
        public IEnumerable<PretplatnaKarticaView> vratiSvePretplatneKartice()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<PretplatnaKarticaView> lista = new List<PretplatnaKarticaView>();
                foreach (PretplatnaKartica k in s.Query<PretplatnaKartica>().ToList())
                {
                    lista.Add(new PretplatnaKarticaView(k));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        public PretplatnaKarticaView vratiPretplatnuKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PretplatnaKartica k = s.Get<PretplatnaKartica>(id);
                if (k != null)
                    return new PretplatnaKarticaView(k);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public String dodajPretplatnuKarticu(PretplatnaKartica k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik korisnik = new Korisnik() { Ime = "Ivan", Prezime = "Petkovic", Jmbg = "1233214326547", Datum_registracije = DateTime.Now };

                k.Korisnik = korisnik;

                s.Save(korisnik);
                s.Save(k);
                s.Flush();
                s.Close();

                return "Uspesno dodata kartica";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }


        public String izbrisiPretplatnuKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var queryString = string.Format("delete {0} where id = :id",
                                        typeof(PretplatnaKartica));
                s.CreateQuery(queryString).SetParameter("id", id).ExecuteUpdate();
                
                s.Flush();
                s.Close();
                return "Uspesno uklonjena kartica";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajPretplatnuKarticu(PretplatnaKartica k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PretplatnaKartica kartica = s.Load<PretplatnaKartica>(k.Id);

                kartica.Vazi_od = k.Vazi_od;
                kartica.Vazi_do = k.Vazi_do;


                s.Update(kartica);
                s.Flush();
                s.Close();

                return "Uspesno azurirana kartica";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }
        #endregion

        #region Rezervacija

        public IEnumerable<RezervacijaView> vratiSveRezervacijeKartice(int karticaID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<RezervacijaView> lista = new List<RezervacijaView>();
                foreach (Rezervacija r in s.Query<Rezervacija>().Where(x => x.Kartica.Id == karticaID).ToList())
                {
                    lista.Add(new RezervacijaView(r));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<RezervacijaView> vratiSveRezervacije()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<RezervacijaView> lista = new List<RezervacijaView>();
                foreach (Rezervacija r in s.Query<Rezervacija>().ToList())
                {
                    lista.Add(new RezervacijaView(r));
                }
                s.Close();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public RezervacijaView vratiRezervaciju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Rezervacija r = s.Get<Rezervacija>(id);
                if (r != null)
                    return new RezervacijaView(r);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public String dodajRezervaciju(Rezervacija r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                r.Parking = s.Load<Parking>(119);
                r.Kartica = s.Load<PretplatnaKartica>(208);
                
                s.Save(r);
                s.Flush();
                s.Close();

                return "Uspesno dodata rezervacija";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }


        public String izbrisiRezervaciju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rezervacija r = s.Load<Rezervacija>(id);

                s.Delete(r);
                s.Flush();
                s.Close();
                return "Uspesno uklonjena rezervacija";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        public String azurirajRezervaciju(Rezervacija r)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Rezervacija rezervacija = s.Load<Rezervacija>(r.Id);

                rezervacija.Vazi_od = r.Vazi_od;
                rezervacija.Vazi_do = r.Vazi_do;


                s.Update(rezervacija);
                s.Flush();
                s.Close();

                return "Uspesno azurirana rezervacija";
            }
            catch (Exception ec)
            {
                return ec.ToString();
            }
        }

        #endregion
    }
}
