using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChannelMonitoring.Utils
{
    public static class Configuracion
    {
        public static IConfigurationRoot CargarConfiguracion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
