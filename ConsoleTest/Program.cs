using ConsoleTest.Services;
using ConsoleTest.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IReadService, ReadService>()
                .AddTransient<ICommandService, CommandService>()
                .AddTransient<IDeleteService, DeleteService>()
                .AddTransient<IUpdateService, UpdateService>()
                .BuildServiceProvider();

            var commandService = serviceProvider.GetService<ICommandService>();

            commandService.RunApp();
        }
    }
}
