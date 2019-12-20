using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public int NrDomu { get; set; }
        public int? NrLokalu { get; set; }
        public string Miasto { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
