using Microsoft.OpenApi.Models;
using StickerAlbum.DatabaseAccess;
using System.Reflection;

namespace StickerAlbum.Api
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
            services.AddStickerAlbumDomain();
            services.AddStickerAlbumDatabaseAccess(Configuration["ConnectionStrings:DefaultConnection"], inMemory: true);
            services.AddAutoMapper(mapConfig => { }, Assembly.GetExecutingAssembly());
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StickerAlbum.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StickerAlbum.Api v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
