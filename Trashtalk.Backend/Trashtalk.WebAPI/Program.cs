using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Trashtalk.Application;
using Trashtalk.Application.Common.Mappings;
using Trashtalk.Application.Interfaces;
using Trashtalk.Persistence;
using Trashtalk.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile(new AssemblyMapingProfile(Assembly.GetExecutingAssembly()));
	cfg.AddProfile(new AssemblyMapingProfile(typeof(ITrashTalkDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
//                ConfigureSwaggerOptions>();


var app = builder.Build();


using (var scope  = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<TrashTalkDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Database creation error. {ex}");
	}
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
