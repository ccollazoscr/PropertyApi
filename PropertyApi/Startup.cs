using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Property.Application.Command;
using Property.Application.Port;
using Property.Application.SeedWork;
using Property.Application.Validator;
using Property.Common.Configuration;
using Property.Common.Converter;
using Property.Infraestructure.Adapter.FileStorage;
using Property.Infraestructure.Adapter.SQLServer.Adapter;
using Property.Infraestructure.Adapter.SQLServer.Repository;
using Property.Infraestructure.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using PropertyApi.Converter;
using PropertyApi.EntryModel;
using PropertyApi.Exception;
using System.IO;
using System.Reflection;

namespace PropertyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PropertyApi", Version = "v1" });
            });
            ConfigureExternalLibraries(services);
            ConfigureApi(services);
            ConfigureApplication(services);
            ConfigureServiceIfraestructure(services);
        }
        private void ConfigureExternalLibraries(IServiceCollection services)
        {
            //Add MediatR configuration
            services.AddMediatR(typeof(CreatePropertyCommand).GetTypeInfo().Assembly);

            //Add Validators
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePropertyCommandValidator>());

            ////Add interceptor validations
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }

        private void ConfigureApi(IServiceCollection services)
        {
            //Converter
            services.AddSingleton(typeof(IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>), typeof(CreatePropertyEntryModelConverter));
        }        

        private void ConfigureApplication(IServiceCollection services)
        {
            //Converter
            services.AddSingleton(typeof(IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>), typeof(CreatePropertyEntryModelConverter));
            services.AddSingleton(typeof(IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding>), typeof(UpdatePropertyEntryModelConverter));
        }

        private void ConfigureServiceIfraestructure(IServiceCollection services)
        {
            //Configuración
            RepositorySettings oRepositorySettings = new RepositorySettings()
                                     .SetConnectionString(Configuration.GetSection("ConnectionStrings:SQLServer").Value);
            services.AddSingleton<IRepositorySettings>(oRepositorySettings);

            GeneralSettings oGeneraSettings = new GeneralSettings().SetRootFolder(Configuration.GetSection("StaticFiles:Root").Value)
                                                              .SetOwnerFolder(Configuration.GetSection("StaticFiles:Owners").Value)
                                                              .SetPropertyFolder(Configuration.GetSection("StaticFiles:Properties").Value)
                                                              .SetHost(Configuration.GetSection("Host").Value);
            services.AddSingleton<IGeneralSettings>(oGeneraSettings);

            //Converter
            services.AddSingleton(typeof(IEntityConverter<PropertyBuilding, PropertyEntity>), typeof(PropertyConverter));
            services.AddSingleton(typeof(IEntityConverter<Owner, OwnerEntity>), typeof(OwnerConverter));
            services.AddSingleton(typeof(IEntityConverter<PropertyImage, PropertyImageEntity>), typeof(PropertyImageConverter));
            services.AddSingleton(typeof(IEntityConverter<PropertyTrace, PropertyTraceEntity>), typeof(PropertyTraceConverter));

            //Repositorios - adaptadores
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyManagerPort, PropertyAdapter>();
            services.AddScoped<IPropertyFinderPort, PropertyAdapter>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerManagerPort, OwnerAdapter>();

            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyImageManagerPort, PropertyImageAdapter>();

            services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
            services.AddScoped<IPropertyTraceManagerPort, PropertyTraceAdapter>();

            services.AddScoped<IImageManagerPort, ImageAdapter>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PropertyApi v1"));
            }

            app.UseHttpsRedirection();

            string staticFiles = Configuration.GetValue<string>("StaticFiles:Root");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, staticFiles)),
                RequestPath = $"/{staticFiles}"
            });

            app.UseRouting();

            app.ConfigureExceptionHandler();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
