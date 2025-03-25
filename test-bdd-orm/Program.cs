using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EntityFramework;
using Services;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Authentication.Cookies; // pour ApplicationDbContext.cs

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=mydatabase.db"));

builder.Services.AddAuthentication(options =>{
            options.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme;
        }
    )
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    })
    .AddGitHub(options =>
    {
        options.ClientId = builder.Configuration["GitHub:ClientId"] ?? string.Empty;
        options.ClientSecret = builder.Configuration["GitHub:ClientSecret"] ?? string.Empty;
       //options.EnterpriseDomain = builder.Configuration["GitHub:ClientEnterpriseDomain"] ?? string.Empty;
        options.Scope.Add("user:email");
        options.SaveTokens = true;
    });
builder.Services.AddAuthorization();
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
//cors après UseHttpsRedirection 
app.UseCors(builder =>
{
    builder
    .WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod();

});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();