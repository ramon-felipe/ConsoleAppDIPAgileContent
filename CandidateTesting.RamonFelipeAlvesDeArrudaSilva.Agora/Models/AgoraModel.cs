using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Models
{
    public class AgoraModel
    {
        public static string Provider { get => "\"Minha CDN\""; }
        public string TimeTaken { get; set; }
        public string StatusCode { get; set; }
        public string UriPath { get; set; }
        public string HttpMethod { get; set; }
        public string ResponseSize { get; set; }
        public string CacheStatus { get; set; }

        public override string ToString()
        {
            return $"{Provider} {HttpMethod} {StatusCode} {UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
        }
    }
}
