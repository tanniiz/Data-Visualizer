using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataVisualizer.UI.Utils
{
    public static class CSVUtils
    {
        public static List<List<string>> ReadCSVFile(string filePath, char delimiter = ',')
        {
            List<List<string>> result = new List<List<string>>();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return result;
            }

            if (!File.Exists(filePath))
            {
                return result;
            } 
            
            if (delimiter == '\0')
            {
                delimiter = ',';
            }

            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {
                Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var fieldValues = new List<string>();
                    foreach (Match match in csvSplit.Matches(line))
                    {
                        fieldValues.Add(match.Value.TrimStart(','));
                    }
                    result.Add(fieldValues);
                }
            }

            return result;
        }
    }
}
