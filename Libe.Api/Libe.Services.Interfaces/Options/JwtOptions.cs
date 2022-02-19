using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Services.Interfaces.Options
{
    public class JwtOptions
    {
        public string Issure { get; set; }
        public string Audience { get; set; }
        public double ExpiresAfterMitutes { get; set; }
        public string SigningKey { get; set; }
        public byte[] SigningKeyBytes => Convert.FromBase64String(SigningKey);

    }
}
