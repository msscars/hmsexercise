using Hms.Exercise.App.ConsoleApp.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Exercise.App.ConsoleApp
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHmsServices();
                });

            try
            {
                return await builder.RunCommandLineApplicationAsync<HmsCommand>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
