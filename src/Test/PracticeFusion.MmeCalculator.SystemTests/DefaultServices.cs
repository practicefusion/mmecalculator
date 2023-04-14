using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PracticeFusion.MmeCalculator.Core.Services;
using PracticeFusion.MmeCalculator.LocalRxNormResolver;
using Serilog;
using System;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace PracticeFusion.MmeCalculator.SystemTests
{
    public class DefaultServices
    {
        private static readonly Lazy<DefaultServices> _instance = new(() => new DefaultServices());

        private DefaultServices()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            var services = new ServiceCollection();
            services.AddLogging(b => b.AddSerilog(dispose: true));
            services.AddDistributedMemoryCache();
            services.AddSingleton<IStringPreprocessor, StringPreprocessor>();
            services.AddSingleton<IRxNormInformationResolver, Client>();
            services.AddSingleton<IOpioidConversionFactor, OpioidConversionFactor>();
            services.AddSingleton<IMmeCalculator, Core.Services.MmeCalculator>();
            services.AddSingleton<IQualityAnalyzer, QualityAnalyzer>();
            services.AddSingleton<IMedicationParser, MedicationParser>();
            services.AddSingleton<ISigParser, SigParser>();
            services.AddSingleton<ICalculator, Calculator>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static DefaultServices ServiceProviderInstance => _instance.Value;

        public static IDistributedCache DistributedCache =>
            _instance.Value.ServiceProvider.GetService<MemoryDistributedCache>();

        public static ILogger Logger =>
            _instance.Value.ServiceProvider.GetService<ILoggerFactory>().CreateLogger("default");

        public static IStringPreprocessor StringPreprocessor =>
            _instance.Value.ServiceProvider.GetService<IStringPreprocessor>();

        public static IRxNormInformationResolver RxNormResolver =>
            _instance.Value.ServiceProvider.GetService<IRxNormInformationResolver>();

        public static IOpioidConversionFactor OpioidConversionFactor =>
            _instance.Value.ServiceProvider.GetService<IOpioidConversionFactor>();

        public static IMedicationParser MedicationParser =>
            _instance.Value.ServiceProvider.GetService<IMedicationParser>();

        public static ISigParser SigParser => _instance.Value.ServiceProvider.GetService<ISigParser>();

        public static IQualityAnalyzer QualityAnalyzer =>
            _instance.Value.ServiceProvider.GetService<IQualityAnalyzer>();

        public static ICalculator Calculator => _instance.Value.ServiceProvider.GetService<ICalculator>();

        public static IMmeCalculator MmeCalculator =>
            _instance.Value.ServiceProvider.GetService<IMmeCalculator>();

        public ServiceProvider ServiceProvider { get; }
    }
}