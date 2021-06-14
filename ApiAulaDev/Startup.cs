using ApiAulaDev.Data;
using ApiAulaDev.Repositorio;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ApiAulaDev.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ApiAulaDev.Models;
using ApiAulaDev.View;

namespace ApiAulaDev
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlite($"Data Source=ApiDev.db"));

            services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));

            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Funcionario, FuncionarioView>().ReverseMap();
           });
            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion



            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiAulaDev", Version = "v1" });

            });
        }

        public void Configure(IApplicationBuilder app, Context dataContext)
        {
            dataContext.Database.Migrate();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAulaDev v1"));

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
