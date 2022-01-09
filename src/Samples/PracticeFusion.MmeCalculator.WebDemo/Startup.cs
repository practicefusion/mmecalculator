using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PracticeFusion.MmeCalculator.Core.Services;
using PracticeFusion.MmeCalculator.RxNavRxNormResolver;

namespace PracticeFusion.MmeCalculator.WebDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSingleton<IStringPreprocessor, StringPreprocessor>();
            services.AddSingleton<IRxNormInformationResolver, Client>();
            services.AddSingleton<IOpioidConversionFactor, OpioidConversionFactor>();
            services.AddSingleton<IMmeCalculator, Core.Services.MmeCalculator>();
            services.AddSingleton<IQualityAnalyzer, QualityAnalyzer>();
            services.AddSingleton<IMedicationParser, MedicationParser>();
            services.AddSingleton<ISigParser, SigParser>();
            services.AddSingleton<ICalculator, Calculator>();
            services.AddSingleton<TransparencyUtils, TransparencyUtils>();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "Practice Fusion MME Calculator API",
                            Description =
                                "An API for calculating morphine milligram equivalence (MME) of opioid prescriptions, using the sig and RxNorm code of the drug. RxNorm results from the RxNorm API at https://rxnav.nlm.nih.gov/RxNormAPIs.html. This service uses publicly available data from the U.S. National Library of Medicine (NLM), National Institutes of Health, Department of Health and Human Services; NLM is not responsible for the product and does not endorse or recommend this or any other product.",
                            Contact = new OpenApiContact
                            {
                                Name = "Practice Fusion",
                                Email = string.Empty,
                                Url = new Uri("https://github.com/JonathanMalek")
                            },
                            License = new OpenApiLicense
                            {
                                Name = "MIT License",
                                Url = new Uri("https://github.com/practicefusion/mmecalculator/blob/master/LICENSE")
                            }
                        });

                    // Set the comments path for the Swagger JSON and UI.
                    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MME Calculator API v1");
                    c.RoutePrefix = "docs";
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
