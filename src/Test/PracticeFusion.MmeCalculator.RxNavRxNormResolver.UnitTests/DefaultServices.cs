using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.UnitTests
{
    public class DefaultServices
    {
        private static readonly Lazy<DefaultServices> _instance = new(() => new DefaultServices());

        private DefaultServices()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();

            var services = new ServiceCollection();
            services.AddLogging(b => b.AddSerilog(Log.Logger, true));

            services.AddDistributedMemoryCache();
            ServiceProvider = services.BuildServiceProvider();
        }

        public static DefaultServices ServiceProviderInstance => _instance.Value;

        public static IDistributedCache DistributedCache =>
            _instance.Value.ServiceProvider.GetService<MemoryDistributedCache>();

        public static ILogger<Client> Logger =>
            _instance.Value.ServiceProvider.GetService<ILoggerFactory>()!.CreateLogger<Client>();

        public ServiceProvider ServiceProvider { get; }
    }
}