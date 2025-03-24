using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EntityFramework;
using Services; // pour ApplicationDbContext.cs

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=mydatabase.db"));

builder.Services.AddAuthentication()
    .AddGitHub(options =>
    {
        options.ClientId = builder.Configuration["GitHub:ClientId"] ?? string.Empty;
        options.ClientSecret = builder.Configuration["GitHub:ClientSecret"] ?? string.Empty;
        options.EnterpriseDomain = builder.Configuration["GitHub:ClientEnterpriseDomain"] ?? string.Empty;
        options.Scope.Add("user:email");
        options.SaveTokens = true;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();