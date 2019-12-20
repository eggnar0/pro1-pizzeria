using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            PizzaSkladnikZamowienie = new HashSet<PizzaSkladnikZamowienie>();
            ProduktZamowienie = new HashSet<ProduktZamowienie>();
        }

        public int Id { get; set; }
        public int KlientId { get; set; }
        public DateTime Data { get; set; }

        public Klient Klient { get; set; }
        public ICollection<PizzaSkladnikZamowienie> PizzaSkladnikZamowienie { get; set; }
        public ICollection<ProduktZamowienie> ProduktZamowienie { get; set; }
    }
}
