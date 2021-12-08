using System;
using System.ComponentModel.DataAnnotations;

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
