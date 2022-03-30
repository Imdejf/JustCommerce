using E_Commerce.Application;
using E_Commerce.Persistence.DependencyInjection;
using E_Commerce.Shared.Configurations;
using E_Commerce.Shared.DependencyInjection;

public class Startup
{
    private IConfiguration _Configuration { get; }
    private bool _IsForTests { get; init; }
    private JwtServiceConfig _JwtServiceConfig { get; init; }

    public Startup(IConfiguration configuration, bool isForTests = false)
    {
        _Configuration = configuration;
        _IsForTests = isForTests;
        _JwtServiceConfig = new JwtServiceConfig();
        _Configuration.GetSection("JWT").Bind(_JwtServiceConfig);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();

        services.AddSharedServices(_Configuration);
        //services.AddAppServices(_Configuration);

        services.AddSwaggerDocumentation();
        services.AddFluentValidators(typeof(ApplicationAssemblyEntryPoint).Assembly);
        services.AddMediator(typeof(ApplicationAssemblyEntryPoint).Assembly);

        if (_IsForTests)
        {
            services.AddInMemoryAuthDbContext(System.Guid.NewGuid().ToString());
        }
        else
        {
            services.AddECommerceDbContext(_Configuration.GetConnectionString("DefaultConnection"));
        }

        services.AddJwtAuthorization(_JwtServiceConfig);
        services.AddIdentity();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwaggerOpenAPI(env);

        app.UseJwtAuthorization();

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseCors(c => c
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseSharedMiddlewares();

        app.UseJwtAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
