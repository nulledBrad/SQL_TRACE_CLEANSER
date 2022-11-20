using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Text;

Console.WriteLine("Hello Its Starting");
var path = @"C:\Users\brad.williamson\TaskLists.csv"; 
using (TextFieldParser csvParser = new TextFieldParser(path))
{
    csvParser.CommentTokens = new string[] { "#" };
    csvParser.SetDelimiters(new string[] { "," });
    csvParser.HasFieldsEnclosedInQuotes = true;

    csvParser.ReadLine();
    var csv = new StringBuilder();
    while (!csvParser.EndOfData)
    {
        string[] fields = csvParser.ReadFields();
        string id =     fields[0];
        string date = fields[1];
        string tag = fields[2];
        string text = fields[3];
        if (fields[3].Contains("SELECT") || fields[3].Contains("UPDATE") || fields[3].Contains("DROP") || fields[3].Contains("CREATE") || fields[3].Contains("DELETE") || fields[3].Contains("INSERT"))
        {
            string row = "";
            if (fields[3].Contains("WHERE") || fields[3].Contains("AND") || fields[3].Contains("ON") || fields[3].Contains(",")

                || fields[3].Contains("LEFT JOIN") || fields[3].Contains("INNER JOIN"))
            {
                row = fields[3].Replace("WHERE", "\nWHERE");
                row = row.Replace("AND", "\nAND");
                row = row.Replace("ON", "\n     ON");
                row = row.Replace("ORDER BY", "\nORDER BY");
                row = row.Replace("GROUP BY", "\nGROUP BY");
                row = row.Replace("LEFT JOIN", "\nLEFT JOIN");
                row = row.Replace("LEFT OUTER JOIN", "\nLEFT OUTER JOIN");
                row = row.Replace("INNER JOIN", "\nINNER JOIN");
                row = row.Replace("RIGHT JOIN", "\nRIGHT JOIN");
                row = row.Replace(",", "\n,");

            } 
            else row = fields[3];
              
            Console.Out.WriteLine(fields[3]);
         
            var newLine = $"{row}";
            csv.AppendLine(newLine);
            var blankLine = "";
            csv.AppendLine(blankLine);
        }
    }
    var filePath = @"C:\Users\brad.williamson\CleansedTaskList.csv";
    File.WriteAllText(filePath, csv.ToString());
    Console.WriteLine("It has completed.");
}