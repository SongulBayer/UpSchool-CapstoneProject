using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Settings
{
    public class JwtSettings
    {
        
        public string SecretKey { get; set; }
        public string Issuer { get; set; }//Kim tarafından oluşturuldu
        public string Audience { get; set; }//Kim için oluşturuldu
        public int ExpiryInMinutes { get; set; }//Token'ın kullanım süresi



    }
}
