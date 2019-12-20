using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Rabat
    {
        public Rabat()
        {
            PizzaTyp = new HashSet<PizzaTyp>();
        }

        public int Id { get; set; }
        public int Wielkosc { get; set; }

        public ICollection<PizzaTyp> PizzaTyp { get; set; }
    }
}
