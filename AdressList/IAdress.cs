using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressList
{
    interface IAdress
    {
        /// <summary>
        /// First name of resident on the adress
        /// </summary>
        string FirstName { get; set; }
        string LastName { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
    }
}
