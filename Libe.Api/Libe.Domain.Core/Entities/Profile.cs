using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Domain.Core.Entities
{
    public class Profile : Base.BaseEntity<int>
    {
        public string Cantry { get; set; }
        public string City { get; set; }
        public DateTime Bearthday { get; set; }
    }
}
