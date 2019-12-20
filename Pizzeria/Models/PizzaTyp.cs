using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaTyp
    {
        public PizzaTyp()
        {
            Pizza = new HashSet<Pizza>();
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
        }

        public int Id { get; set; }
        public int Nazwa { get; set; }
        public int? RabatId { get; set; }
        public int Cena { get; set; }

        public Rabat Rabat { get; set; }
        public ICollection<Pizza> Pizza { get; set; }
        public ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
    }
}
