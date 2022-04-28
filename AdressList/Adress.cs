using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressList
{
    class cAdress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public override string ToString() => $"{FirstName} {LastName} in {Country}";

        public static class Factory
        {
            public static cAdress CreateRandom()
            {
                var rnd = new Random();

                var _fnames = "Martin, Maria, John, Kim, Susanne, Franz, Bettina".Split(',');
                var _lnames = "Lenart, Andersson, Ramirez, Smith, Jose, Heniz, Waldblaume".Split(',');
                var _countries = "Sverige, Tyskland, Spanien".Split(',');
                var fn = _fnames[rnd.Next(0, _fnames.Length)];
                var ln = _lnames[rnd.Next(0, _lnames.Length)];
                var ctry = _countries[rnd.Next(0, _countries.Length)];

                return new cAdress { FirstName = fn, LastName = ln, Country = ctry };
            }
        }
    }

    struct sAdress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public override string ToString() => $"{FirstName} {LastName} in {Country}";

        public static class Factory
        {
            public static sAdress CreateRandom()
            {
                var rnd = new Random();

                var _fnames = "Martin, Maria, John, Kim, Susanne, Franz, Bettina".Split(',');
                var _lnames = "Lenart, Andersson, Ramirez, Smith, Jose, Heniz, Waldblaume".Split(',');
                var _countries = "Sverige, Tyskland, Spanien".Split(',');
                var fn = _fnames[rnd.Next(0, _fnames.Length)];
                var ln = _lnames[rnd.Next(0, _lnames.Length)];
                var ctry = _countries[rnd.Next(0, _countries.Length)];

                return new sAdress { FirstName = fn, LastName = ln, Country = ctry };
            }
        }
    }

}
