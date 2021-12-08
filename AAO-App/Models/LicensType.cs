using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class LicensType
    {
        [Key]
        public int LicensTypeId { get; set; }
        public string LicensName { get; set; }
        public DateTime LicensExpDate { get; set; }
        public Byte[] LicensImage { get; set; }
    }
}
