using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnikZamowienie = new HashSet<PizzaSkladnikZamowienie>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public string Wielkosc { get; set; }
        public string Ciasto { get; set; }

        public PizzaTyp PizzaNavigation { get; set; }
        public ICollection<PizzaSkladnikZamowienie> PizzaSkladnikZamowienie { get; set; }
    }
}
