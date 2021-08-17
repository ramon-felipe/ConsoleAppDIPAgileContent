using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.RestRequest
{
    public interface IHttpRequest
    {
        Task<string> Get(string uri);
    }
}
