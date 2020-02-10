using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using OohInterview.DependencyInjection;

namespace OohInterview.Api
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
            services.AddCors();
            
            services.AddControllers();
            
            services
                .AddDatabase()
                .AddQueries();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors(
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            
            app.UseEndpoints(ConfigureEndpoints);
            ConfigureUserInterface(app);
           
        }

        private static void ConfigureEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
            AddRootEndpoint(endpoints);
        }

        private static void AddRootEndpoint(IEndpointRouteBuilder endpoints)
        {
            const string root = "/";
            endpoints.MapGet(
                root,
                context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.NoContent;
                    return context.Response.CompleteAsync();
                });
        }

        private void ConfigureUserInterface(IApplicationBuilder app)
        {
            var rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var contentDirectory = Configuration.GetSection("UI")["ContentDirectory"];
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(rootDirectory, contentDirectory)),
            });
        }
    }
}