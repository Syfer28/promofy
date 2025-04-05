using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using PROMHUB.Data;
using PROMHUB.Controllers;

Console.WriteLine("Command line arguments:");
foreach (var arg in args)
{
    Console.WriteLine(arg);
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ServiceClassDataCompanyDistributorProductTables>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ImageService>();

var app = builder.Build();

// Configure CORS
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:8081") 
           .AllowAnyHeader()                     
           .AllowAnyMethod();                    
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Enable serving static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "wwwroot", "img")),
    RequestPath = "/img"
});

app.Run();
