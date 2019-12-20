using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class ProduktZamowienie
    {
        public int ProduktId { get; set; }
        public int ZamowienieId { get; set; }
        public int Ilosc { get; set; }

        public Produkt Produkt { get; set; }
        public Zamowienie Zamowienie { get; set; }
    }
}
