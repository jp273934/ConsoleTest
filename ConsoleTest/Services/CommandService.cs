using ConsoleTest.Services.Interfaces;
using System;

namespace ConsoleTest.Services
{
    public class CommandService : ICommandService
    {
        private readonly IReadService _readService;
        private readonly IDeleteService _deleteService;
        private readonly IUpdateService _updateService;

        public CommandService(IReadService readService, IDeleteService deleteService, IUpdateService updateService)
        {
            _readService   = readService;
            _deleteService = deleteService;
            _updateService = updateService;
        }

        public void RunApp()
        {
            while(true)
            {
                Console.WriteLine("Do you wish to read all rows or read individual rows or delete a row? or update a row Enter Read All or Read Specific or Delete or Update");

                var answer = Console.ReadLine();

                if(answer == "Read All" || answer == "Read Specific")
                {
                    ReadData(answer);
                    break;
                }

                if(answer == "Delete")
                {
                    DeleteData();
                    break;
                }

                if(answer == "Update")
                {
                    UpdateData();
                    break;
                }

                Console.WriteLine("Invalid command");
            }
        }

        private void ReadData(string command)
        {
            if(command == "Read All")
            {
                _readService.ReadData();
            } else
            {
                while(true)
                {
                    Console.WriteLine("Enter Api Number");
                    string apiString = Console.ReadLine();

                    long apiNumber;

                    if (long.TryParse(apiString, out apiNumber))
                    {
                        while(true)
                        {
                            Console.WriteLine("Do you wish enter a tank number ? Y/N");

                            var answer = Console.ReadLine();

                            if(answer == "Y" || answer == "N")
                            {
                                if(answer == "Y")
                                {
                                    while(true)
                                    {
                                        Console.WriteLine("Enter a tank number");
                                        int tankNumber;
                                        var tankString = Console.ReadLine();

                                        if(int.TryParse(tankString, out tankNumber))
                                        {
                                            _readService.ReadDataRow(apiNumber, tankNumber);
                                            break;

                                        } else
                                        {
                                            Console.WriteLine("Tank number must be a numberic input");
                                        }

                                        break;
                                    }
                                } else
                                {
                                    _readService.ReadDataRow(apiNumber);
                                    break;
                                }
                            }

                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input must be a integer value ");
                    }

                    break;
                }
               
            }
        }

        private void DeleteData()
        {
            while(true)
            {
                var apiNumberValue = "";
                long apiNumber;

                Console.WriteLine("Enter Api Numbeer");
                apiNumberValue = Console.ReadLine();

                if(long.TryParse(apiNumberValue, out apiNumber))
                {                  
                    while(true)
                    {
                        var tankNumberValue = "";
                        int tankNumber;

                        Console.WriteLine("Enter Tank number");
                        tankNumberValue = Console.ReadLine();

                        if(int.TryParse(tankNumberValue, out tankNumber))
                        {
                            _deleteService.DeleteRow(apiNumber, tankNumber);
                            break;
                        } else
                        {
                            Console.WriteLine("Input must be a numeric value");
                        }
                    }
                } else
                {
                    Console.WriteLine("Input must be a numeric value");
                }

                break;
            }
        }

        private void UpdateData()
        {
            while(true)
            {

                Console.WriteLine("Enter Api number");
                string apiNumberValue = Console.ReadLine();

                if (long.TryParse(apiNumberValue, out long apiNumber))
                {
                    while(true)
                    {
                        Console.WriteLine("Enter tank number");

                        var tankNumberValue = Console.ReadLine();
                        int tankNumber;

                        if (int.TryParse(tankNumberValue, out tankNumber))
                        {
                            while(true)
                            {
                                Console.WriteLine("Which field do you wish to update? Owner(0) Api#(1) Longitute(2) Latitude(3) Property#(4) Lease/Well Name(5) Tank MID(6) Tank Nbr(7) Tank Size(8) BBLS Per Inch(9)");
                                string fieldNumberValue = Console.ReadLine();

                                if(int.TryParse(fieldNumberValue, out int fieldNumber))
                                {
                                    while(true)
                                    {
                                        Console.WriteLine("Enter the new value to be updated");
                                        var newValue = Console.ReadLine();

                                        _updateService.UpdateRow(apiNumber, tankNumber, fieldNumber, newValue);
                                        break;
                                    }

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Input must be a numeric value");
                                    continue;
                                }
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Input must be a numberic value");
                            continue;
                        }

                    }

                } else
                {
                    Console.WriteLine("Input must be a numeric value");
                    continue;
                }

                break;
            }
        }

        private void SetApiNumberAndTankNumber()
        {

        }
    }
}
