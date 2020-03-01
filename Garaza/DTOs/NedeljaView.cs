using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garaza.Entiteti;

namespace Garaza.DTOs
{
    [Serializable]
    public class NedeljaView
    {
        public DateTime Pocetak_nedelje { get; set; }
        public OsobaView Kontroler { get; set; }
        public OsobaView Prva_smena { get; set; }
        public OsobaView Druga_smena { get; set; }
        public OsobaView Treca_smena { get; set; }

        public NedeljaView(Nedelja n)
        {
            Pocetak_nedelje = n.Pocetak_nedelje;
            Kontroler = new OsobaView(n.Kontroler);
            Prva_smena = new OsobaView(n.Prva_smena);
            Druga_smena = new OsobaView(n.Druga_smena);
            Treca_smena = new OsobaView(n.Treca_smena);
        }
    }
}
