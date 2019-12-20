using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }

        public ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
    }
}
