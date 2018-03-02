using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGBackend.Contexts;

namespace TGBackend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AlunoContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("TGBackend")))
                .AddDbContext<CursoContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("TGBackend")))
                .AddDbContext<OcorrenciaContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("TGBackend")))
                .AddDbContext<TipoOcorrenciaContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("TGBackend")))
                .AddDbContext<VeiculoContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("TGBackend")));
            //services.AddDbContext<AlunoContext>(opt => opt.UseInMemoryDatabase("AlunoList"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}