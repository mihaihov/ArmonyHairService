using Infrastructure;

namespace ArmonyHairService
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructureServices();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ArmonyHair", builder => builder.WithOrigins("https://armonyhair.ro","http://armonyhair.ro").AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("ArmonyHair");
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
