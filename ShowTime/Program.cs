using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShowTime.Components;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Implementation;
using ShowTime.Repositories.Implementation.BandFestivalRepository;
using ShowTime.Repositories.Implementation.BandRepository;
using ShowTime.Repositories.Implementation.FestivalRepository;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Interfaces.BandFestivalRepository;
using ShowTime.Repositories.Interfaces.BandRepository;
using ShowTime.Repositories.Interfaces.FestivalRepository;
using ShowTime.Services.Implementation;
using ShowTime.Services.Implementation.BandFestivalService;
using ShowTime.Services.Implementation.BandService;
using ShowTime.Services.Implementation.FestivalService;
using ShowTime.Services.Interfaces;
using ShowTime.Services.Interfaces.BandFestivalService;
using ShowTime.Services.Interfaces.BandService;
using ShowTime.Services.Interfaces.FestivalService;
using Showtime.Components.Account;

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
builder.Services.AddScoped<IBandFestivalRepository, BandFestivalRepository>();
builder.Services.AddScoped<IBandFestivalService, BandFestivalService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<ShowTimeDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddAuthenticationCore();
builder.Services.AddAntiforgery();


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

app.MapAdditionalIdentityEndpoints();

await app.RunAsync();
