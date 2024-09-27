using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MovieSearchBlazorApp.Data;
using MovieSearchBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<MovieService>();
builder.Services.AddHttpClient<MovieService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTelerikBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
