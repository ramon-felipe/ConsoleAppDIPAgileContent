using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Enums;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.RestRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Persistance
{
    public class FilePersistance : IFilePersistance
    {
        private readonly IHttpRequest _httpRequest;

        public FilePersistance(IHttpRequest httpRequest)
        {
            _httpRequest = httpRequest;

        }


        public async Task<List<string>> GetLogContentAsList(string uri)
        {
            var content = await GetLogContent(uri);
            var contentAsList = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                       .ToList();
            return contentAsList;
        }

        private async Task<string> GetLogContent(string uri)
        {
            try
            {
                var result = await _httpRequest.Get(uri);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting the content of the uri: {uri}.\n{e.Message}");
            }

        }

        /// <summary>
        /// Saves the file in the informed path 
        /// </summary>
        /// <param name="contentList"></param>
        /// <param name="destinationPath"></param>
        public void SaveFile(IEnumerable<string> contentList, string destinationPath)
        {
            try
            {
                using var tw = new StreamWriter(VerifiesFileExtensionAndDir(destinationPath));
                foreach (var line in contentList)
                    tw.WriteLine(line);
            }
            catch (Exception e)
            {
                throw new Exception($"Error saving the log file.\n{e.Message}");
            }
        }


        private static string VerifiesFileExtensionAndDir(string destinationPath)
        {
            try
            {
                var fileNameAndExtensionRegex = new Regex(@"/(\w*[.]txt$)");
                var fileNameAndExtension = fileNameAndExtensionRegex.Match(destinationPath).Groups[1].ToString();
                var fileLocation = destinationPath.Replace(fileNameAndExtension, "");

                if (!destinationPath.ToLower().EndsWith(FileExtension.TXT))
                    destinationPath += $"//file{FileExtension.TXT}";

                Directory.CreateDirectory(fileLocation);

                return destinationPath;
            }
            catch (Exception)
            {
                throw new Exception("Error verifying file extension and creating the destination directory.");
            }

        }
    }
}
