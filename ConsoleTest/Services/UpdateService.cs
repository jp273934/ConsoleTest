using ConsoleTest.Services.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest.Services
{
    public class UpdateService : IUpdateService
    {
        public void UpdateRow(long apiNumber, int tankNumber, int fieldNumber, string fieldValue)
        {
            var lines = File.ReadAllLines("Well Data.csv");
            var linesToWrite = new List<string>();

            for(var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(",");

                if(line[1] == apiNumber.ToString() && line[8] == tankNumber.ToString())
                {
                    line[fieldNumber] = fieldValue;
                    lines[i] = string.Join(",", line);
                }

                linesToWrite.Add(lines[i]);
            }

            File.WriteAllLines("Well Data.csv", linesToWrite);
        }
    }
}
