using System;
using System.IO;
using System.Collections.Generic;

namespace Colors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] identityRanges = new string[]
            {
                "B3:B102",
                "E3:E102",
                "H3:H102",
                "K3:K102",
                "N3:N102",
                "Q3:Q102"
            };

            foreach (string range in identityRanges)
            {
                // CreateIdentityFileSet(range);
            }

            string[] diversityRanges = new string[]
            {
                "M11:M15",
                "N11:N15",
                "O11:O15",
                "P11:P15",
                "Q11:Q15",
                "R11:R15",
                "S11:S15"
            };

            foreach (string range in diversityRanges)
            {
                CreateDiversityIndexFile(range);
            }
        }

        public static void CreateDiversityIndexFile(string range)
        {
            string formula = GoogleDiversityIndexFormatter(range);
            string path = $"C:/Users/jason/OneDrive/Documents/Projects/Programming/Magic/Colors/DiversityFiles/{range[0]}";

            Directory.CreateDirectory(path);

            File.WriteAllText($"{path}/Diversity.txt", formula);
        }

        public static void CreateIdentityFileSet(string range)
        {
            string[] colors = new string[] { "Black", "Blue", "Green", "Red", "White" };

            foreach (string color in colors)
            {
                CreateIdentityFile("Cube Cards", range, color);
            }
        }

        public static void CreateIdentityFile(string sheetName, string range, string color)
        {
            string formula = GoogleFormatter(sheetName, range, color);
            string path = $"C:/Users/jason/OneDrive/Documents/Projects/Programming/Magic/Colors/IdentityFiles/{range[0]}";

            Directory.CreateDirectory(path);

            File.WriteAllText($"{path}/{color}IdentityFormula.txt", formula);
        }
        
        public static List<Identity> ColorCombos(string color)
        {
            List<Identity> identityList = new();
            
            List<Identity> allIdentities = Identity.CreateIdentities();

            foreach (Identity identity in allIdentities)
            {
                foreach (Color c in identity.Colors)
                {
                    if (c.Name == color)
                    {
                        identityList.Add(identity);
                    }
                }
            }

            return identityList;
        }

        public static string GoogleFormatter(string sheetName, string range, string color)
        {
            List<Identity> colorIdentities = ColorCombos(color);
            List<string> countIfList = new();

            foreach (Identity identity in colorIdentities)
            {
                string countIf = GoogleCountIfFormatter(sheetName, range, identity);

                countIfList.Add(countIf);
            }

            string formula = $"={String.Join(" + ", countIfList)}";

            return formula;
        }

        public static string GoogleCountIfFormatter(string sheetName, string range, Identity identity)
        {
            return $"COUNTIF('{sheetName}'!{range},\"*{identity.Name}*\")";
        }

        public static string GoogleDiversityIndexFormatter(string range)
        {
            string numerator = FormatNumerator(range);
            string denominator = $"SUM({range}) * (SUM({range}) - 1)";

            return $"=ROUND(1 - (({numerator}) / ({denominator})), 3)";
        }

        public static string FormatNumerator(string range)
        {
            string[] split = range.Split(':');

            string start = split[0];
            string end = split[1];

            int startRow = Int32.Parse(String.Concat(start.Where(Char.IsDigit)));
            int endRow = Int32.Parse(String.Concat(end.Where(Char.IsDigit)));
            string col = String.Concat(start.Where(Char.IsLetter));

            List<string> numeratorList = new();

            for (int i = startRow; i <= endRow; i++)
            {
                string cell = $"{col}{i}";
                string numerator = $"({cell} * ({cell} - 1))";

                numeratorList.Add(numerator);
            }

            string formula = $"{String.Join(" + ", numeratorList)}";

            return formula;
        }
    }
}