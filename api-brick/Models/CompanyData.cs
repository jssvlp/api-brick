using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class CompanyData
    {
        public string Name { get; set; }
        public string FirstPhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }

    }

    
}
