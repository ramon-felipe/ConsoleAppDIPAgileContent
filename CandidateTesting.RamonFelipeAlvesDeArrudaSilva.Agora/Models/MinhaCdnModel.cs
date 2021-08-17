using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Models
{
    public class MinhaCdnModel
    {
        public string TimeTaken { get; set; }
        public string StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string[] HttpMethod { get; set; }
        public string ResponseSize { get; set; }

    }
}
