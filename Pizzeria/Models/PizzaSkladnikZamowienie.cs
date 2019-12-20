using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaSkladnikZamowienie
    {
        public int ZamowienieId { get; set; }
        public int PizzaSkladnikId { get; set; }

        public Pizza PizzaSkladnik { get; set; }
        public Zamowienie Zamowienie { get; set; }
    }
}
