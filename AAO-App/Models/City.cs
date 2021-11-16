using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public Country Countries { get; set; }
        public string CityName { get; set; }
        public string Zipcode { get; set; }
    }
}
