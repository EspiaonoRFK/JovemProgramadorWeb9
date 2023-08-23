using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var connectionstring = builder.Configuration.GetConnectionString("StringConexao");
builder.Services.AddDbContext<BancoContexto>(options => options.UseSqlServer(connectionstring));



builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
var app = builder.Build();

// Configure o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

