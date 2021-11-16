using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class Country
    {

        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        [MaxLength(2)]
         public string CountryCode { get; set; }
    }
}
