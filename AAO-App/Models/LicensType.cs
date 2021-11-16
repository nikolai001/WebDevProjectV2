using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App.Models
{
    public class LicensType
    {

            [Key]
            public int LicensTypeId { get; set; }
            public string LicensName { get; set; }
            public DateTime LicensExpDate { get; set; }
            public Byte[] LicensImage  { get; set; }

    }

  
}
