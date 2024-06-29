chmod +x init_shared.sh

./init_shared.sh ../FOLDER NAMEPSACE


Esto va en appsetting.json
```json 
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost,3306;Uid=root;pwd=12345678;Database=TravelsDb"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Packages que van en csproj
```csharp
<ItemGroup>
        <!-- Dependency Injection related packages -->
        <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
        <!-- Entity Framework Core related packages -->
        <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.4" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.4" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Relational.Design" Version="1.1.6" />
        <!-- MySQL Database related packages -->
        <PackageReference Include="MySql.EntityFrameworkCore" Version="8.0.2" />
        <!-- Audit trails related packages -->
        <PackageReference Include="EntityFrameworkCore.CreatedUpdatedDate" Version="8.0.0" />
        <!-- Naming conventions related packages -->
        <PackageReference Include="Humanizer" Version="2.14.1" />
        <!-- OpenAPI Documentation related packages -->
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0"/>
        <PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="6.5.0"/>
    </ItemGroup>
```

Esto en Program.cs
```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration

builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepositoryImpl>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For exeption handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```