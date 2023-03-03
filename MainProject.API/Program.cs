
// Setup low-level functionality like configuration providers, etc.
using LibraryClass.Repositories;
using LibraryClass.Repositories.Repositories;
using LibraryClass.Services.Services;
using LibraryClass.Services.Services.Interfaces;
using MainProject.API.Swashbukle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

void ConfigureHost(ConfigureHostBuilder host)
{
}

// Setup services like database providers, etc.
void ConfigureServices(WebApplicationBuilder builder)
{
    // Setup the database using the ApplicationDbContext
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(  // Connect to the Postgres database
            builder.Configuration.GetConnectionString("DefaultConnection"),
            options =>
            {
                // Configure what project we want to store our Code-First Migrations in
                options.MigrationsAssembly("LibraryClass.Repositories");
            })
        );

    builder.Services.AddControllers();

    
    // Setup authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.Authority = builder.Configuration.GetSection("Auth0").GetValue<string>("Domain");
            options.Audience = builder.Configuration.GetSection("Auth0").GetValue<string>("Audience");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                RoleClaimType = "http//schema.marketforyou.com/roles"  //Iam not sure if this is the correct one?
            };
            //
        });
    // Add Swagger generator to create JSON documentation content
   builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "MainProject API", Version = "v1" });

        var apiXmlFilename = Path.Combine(AppContext.BaseDirectory, "MainProject.API.xml");
        var modelsXmlFilename = Path.Combine(AppContext.BaseDirectory, "LibraryClass.xml");
        options.IncludeXmlComments(apiXmlFilename);  //  enable when the doc is enable
        options.IncludeXmlComments(modelsXmlFilename);

        options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Scheme = "bearer"
        });
        options.OperationFilter<AuthHeaderOperationFilter>();
    });


    // Setup dependency injection
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  //or addsingleton
    builder.Services.AddScoped<IProductService, ProductService>();//services
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUploadService, UploadService>();
}

// Setup our HTTP request/response pipeline
void ConfigurePipeline(WebApplication app)
{

    // Allow hosting of static web pages
    if (!app.Environment.IsProduction())
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseSwagger();// to make swagger Json available

        //swager website UI
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Main Project API V1");
        });
    }
    //app.UseHttpsRedirection();


    app.UseAuthentication(); // to auth

    app.UseAuthorization();

    app.MapControllers();
}

//to excecute the migrations to avout error relation 95

void ExecuteMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}


// Create the WebApplicationBuilder instance
var builder = WebApplication.CreateBuilder(args);

// Setup the application
ConfigureHost(builder.Host);
ConfigureServices(builder);

var app = builder.Build();

// Execute migrations on startup
ExecuteMigrations(app);

// Setup the HTTP pipeline
ConfigurePipeline(app);

app.Run();