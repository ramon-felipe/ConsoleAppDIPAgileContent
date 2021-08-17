using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a list of string into a list of <see cref="MinhaCdnModel"/>
        /// </summary>
        /// <param name="minhaCdnlogLines"></param>
        /// <returns></returns>
        public static IEnumerable<MinhaCdnModel> ToMinhaCdnModel(this List<string> minhaCdnlogLines)
        {
            if (minhaCdnlogLines == null || !minhaCdnlogLines.Any())
                return null;

            var regex = new Regex("^\\d*");
            var result = minhaCdnlogLines.Select(m => m.Split("|")).ToList();

            var cdnLogLines = result.Select(r => new MinhaCdnModel
            {
                ResponseSize = r[0],
                StatusCode = r[1],
                CacheStatus = r[2],
                HttpMethod = SeparateHttpMethodAndUriPath(r[3]),
                TimeTaken = regex.Match(r[4]).Value
            });

            return cdnLogLines;
        }

        /// <summary>
        /// Creates an array of strings separating the HTTP Method and URI Path
        /// </summary>
        /// <param name="fullHttpMethod"></param>
        /// <returns></returns>
        private static string[] SeparateHttpMethodAndUriPath(string fullHttpMethod) => 
            fullHttpMethod.Replace("\"", "").Split(" ");

    }
}
