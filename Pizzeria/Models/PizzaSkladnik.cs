using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaSkladnik
    {
        public int PizzaId { get; set; }
        public int SkladnikId { get; set; }

        public PizzaTyp Pizza { get; set; }
        public Skladnik Skladnik { get; set; }
    }
}
