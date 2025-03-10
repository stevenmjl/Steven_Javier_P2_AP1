using Microsoft.EntityFrameworkCore;
using Steven_Javier_P2_AP1.Components;
using Steven_Javier_P2_AP1.DAL;
using Steven_Javier_P2_AP1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));
builder.Services.AddScoped<Estudiantes>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
