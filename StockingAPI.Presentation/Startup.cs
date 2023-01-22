using Microsoft.EntityFrameworkCore;
using Stocking.Domain.Interfaces;
using Stocking.Domain.Services;
using Stocking.Infrastruture;
using Stocking.Infrastruture.Repositories;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration["ConnectionStrings:DbContext"];
        services.AddDbContext<StockContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DbContext"));
        });
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddScoped(typeof(IArticleService), typeof(ArticleService));
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddCors();// angular
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(options =>
                        options.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
            );
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Detail v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

