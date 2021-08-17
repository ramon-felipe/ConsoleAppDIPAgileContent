using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.FormatLog
{
    public interface ILogFormat
    {
        Task<IEnumerable<string>> FormatLog(string logUri);
    }
}
