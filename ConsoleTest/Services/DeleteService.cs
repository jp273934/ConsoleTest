using ConsoleTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest.Services
{
    public class DeleteService : IDeleteService
    {
        public void DeleteRow(long ApiNumber, int TankNumber)
        {
            var lines = File.ReadAllLines("Well Data.csv");
            var linesToWrite = new List<string>();

            for(var i = 0; i < lines.Length; i++)
            {
                if(i > 0)
                {
                    var line = lines[i].Split(",");

                    if (line[1] != ApiNumber.ToString() || line[8] != TankNumber.ToString())
                    {
                        linesToWrite.Add(lines[i]);
                    }
                }
            }

            File.WriteAllLines("Well Data.csv", linesToWrite);

            Console.WriteLine("Row deleted succesfully");
        }
    }
}
