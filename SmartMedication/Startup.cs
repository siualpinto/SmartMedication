using BussinessLogic.Loaders;
using BussinessLogic.Managers;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartMedication.Installers;
using WebApi.Controllers;
using WebApi.HttpStrategies.Gets;
using WebApi.HttpStrategies.Post;

namespace SmartMedication
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartMedication", Version = "v1" });
            });

            services.AddDatabaseConfig(Configuration);
            services.AddMvc().AddApplicationPart(typeof(MedicationController).Assembly).AddControllersAsServices();
            services.AddFactory<IGetAllMedicationStrategy, GetAllMedicationStrategy>();
            services.AddFactory<IPostMedicationStrategy, PostMedicationStrategy>();
            services.AddFactory<IDeleteMedicationStrategy, DeleteMedicationStrategy>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddTransient<IMedicationLoader, MedicationLoader>();
            services.AddTransient<IMedicationManager, MedicationManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartMedication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
