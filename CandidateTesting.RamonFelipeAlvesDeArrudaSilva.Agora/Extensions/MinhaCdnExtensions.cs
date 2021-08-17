using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Extensions
{
    public static class MinhaCdnExtensions
    {
        public static IEnumerable<AgoraModel> ToAgoraModel(this IEnumerable<MinhaCdnModel> minhaCdnList)
        {
            if (minhaCdnList == null || !minhaCdnList.Any())
                return null;

            return minhaCdnList.Select(cdn => new AgoraModel
            {
                HttpMethod = cdn.HttpMethod[0],
                StatusCode = cdn.StatusCode,
                UriPath = cdn.HttpMethod[1],
                TimeTaken = cdn.TimeTaken.ToString(),
                ResponseSize = cdn.ResponseSize,
                CacheStatus = cdn.CacheStatus
            });
        }        
    }
}
