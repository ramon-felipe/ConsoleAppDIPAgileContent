using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Persistance
{
    public interface IFilePersistance
    {
        Task<List<string>> GetLogContentAsList(string uri);
        void SaveFile(IEnumerable<string> contentList, string destinationPath);
    }
}
