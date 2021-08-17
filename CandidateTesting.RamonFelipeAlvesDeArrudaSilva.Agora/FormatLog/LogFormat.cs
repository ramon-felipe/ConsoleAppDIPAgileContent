using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Extensions;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Models;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.FormatLog
{
    public class LogFormat : ILogFormat
    {
        private readonly IFilePersistance _filePersistance;

        public LogFormat(IFilePersistance filePersistance)
        {
            _filePersistance = filePersistance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logUri"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> FormatLog(string logUri)
        {
            var logContent = await _filePersistance.GetLogContentAsList(logUri);
            var logAsCdnFormatList = logContent.ToMinhaCdnModel();
            var logAsAgoraFormatList = logAsCdnFormatList.ToAgoraModel();

            return ToListOfString(logAsAgoraFormatList);
        }

        /// <summary>
        /// Transform the list of <see cref="AgoraModel"/> int a list of <see cref="string"/>
        /// </summary>
        /// <param name="agoraList"></param>
        /// <returns></returns>
        private static IEnumerable<string> ToListOfString(IEnumerable<AgoraModel> agoraList) =>        
            agoraList.ToList().Select(a => a.ToString());
        
    }
}
