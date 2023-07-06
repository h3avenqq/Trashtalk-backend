using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
    .AddInMemoryClients(new List<Client>())
    .AddDeveloperSigningCredential();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
