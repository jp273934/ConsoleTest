using ConsoleTest.Models;
using ConsoleTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleTest.Services
{
    public class ReadService : IReadService
    {
        public void ReadData()
        {
            var list = GetAllWellData();

            foreach (var row in list)
            {
                ReadRow(row);
            }
        }

        public void ReadDataRow(long ApiNumber, int tankNumber = 0)
        {
            var data = GetAllWellData();
            WellDataRow row;

            if (tankNumber > 0)
            {
                row = data.FirstOrDefault(r => r.ApiNumber == ApiNumber && r.TankNumber == tankNumber);
            }
            else
            {
                row = data.FirstOrDefault(r => r.ApiNumber == ApiNumber);
            }

            if(row != null)
            {
                ReadRow(row);
            } else
            {
                Console.WriteLine("No row found !!!");
            }
        }
           
        
        public IEnumerable<WellDataRow> GetAllWellData()
        {
            var list = new List<WellDataRow>();

            using (var reader = new StreamReader(@"Well Data.csv"))
            {
                int counter = 0;
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (counter > 0)
                    {

                        var values = line.Split(",");
                        var row = GetWellDataRow(values);

                        list.Add(row);
                    }

                    counter++;
                }

                
            }

            return list;
        }


        private WellDataRow GetWellDataRow(string[] values)
        {
            var row = new WellDataRow
            {
                Owner = values[0],
                ApiNumber = Convert.ToInt64(values[1]),
                Longitude = Convert.ToDouble(values[2]),
                Latitude = Convert.ToDouble(values[3]),
                PropertyNumber = Convert.ToInt32(values[4]),
                LeaseOrWellName = values[5],
                TankMid = Convert.ToInt32(values[6]),
                TankName = values[7],
                TankNumber = Convert.ToInt32(values[8]),
                TankSize = Convert.ToDouble(values[9]),
                BblsPerInce = Convert.ToDouble(values[10])
            };

            return row;
        }

        private void ReadRow(WellDataRow row)
        {
            Console.WriteLine("Owner : " + row.Owner + " Api Number : " + row.ApiNumber + " Longitude : " + row.Longitude + " Latitute : " + row.Latitude + " Proptery # : " + row.PropertyNumber + " Lease/Well Name : " + row.LeaseOrWellName + " Tank Mi Id : " + row.TankMid + " Tank Name : " + row.TankName + " Tank # : " + row.TankName + " Tank Size : " + row.TankSize + " Bbls Per Ince : " + row.BblsPerInce + "/n");
        }
    }
}
