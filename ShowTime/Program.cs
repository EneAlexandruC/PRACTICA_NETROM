using ShowTime.Components;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using ShowTime.Context;
using Microsoft.EntityFrameworkCore;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Implementation;
using ShowTime.Services.Interfaces;
using ShowTime.Services.Implementation;
using ShowTime.Services.Interfaces.BandService;
using ShowTime.Services.Implementation.BandService;
using ShowTime.Repositories.Interfaces.BandRepository;
using ShowTime.Repositories.Interfaces.FestivalRepository;
using ShowTime.Repositories.Implementation.BandRepository;
using ShowTime.Repositories.Implementation.FestivalRepository;
using ShowTime.Services.Interfaces.FestivalService;
using ShowTime.Services.Implementation.FestivalService;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("ShowTimeDbConnectionString")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<ShowTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<IBandRepository, BandRepository>();
builder.Services.AddScoped<IFestivalService, FestivalService>();
builder.Services.AddScoped<IFestivalRepository, FestivalRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

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

await app.RunAsync();
