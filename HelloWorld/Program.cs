using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This config creation allows for the Port to be passed in to the application when the Droplet
            //is spun up on the Diego Cell
            var config = new ConfigurationBuilder()
                            .AddCommandLine(args)
                            .Build();

            //We then inject this config into the WebHostBuilder which then Runs the application.
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
