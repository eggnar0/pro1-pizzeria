using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            ProduktZamowienie = new HashSet<ProduktZamowienie>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public int Cena { get; set; }

        public ICollection<ProduktZamowienie> ProduktZamowienie { get; set; }
    }
}
