using System.Configuration;
using EasyData.EntityFrameworkCore;
using EasyData.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Extensions;
using ImageHelper.Services;
using MailProvider.Services;
using MailProvider.Services.Interfaces;
using OfficeOpenXml;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.Areas.Admin.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = false; })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookieValue = "true";
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithMethods("GET", "POST", "PUT", "DELETE")
            .WithOrigins("https://maps.googleapis.com", "https://cdn.jsdelivr.net")
            .AllowAnyHeader();
    });
});

builder.Services.AddApplicationServices(typeof(IHomeService));
builder.Services.AddApplicationServices(typeof(IAdminActionsService));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IFileUploadService, FileUploadService>();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// TODO: Provide proper Email and Map credentials (as ENV) before deployment
var googleMapApi = builder.Configuration["GoogleMapApi:ApiKey"];
var emailUsernameKey = builder.Configuration["Email:UsernameKey"];
var emailpassKey = builder.Configuration["Email:PassKey"];


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.ConfigureMigrations();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapEasyData(options => { options.UseDbContext<ApplicationDbContext>(opts => { LoaderOptionsBuilder(opts); }); });

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

await app.RunAsync();

void LoaderOptionsBuilder(DbContextMetaDataLoaderOptions dbContextMetaDataLoaderOptions)
{
    dbContextMetaDataLoaderOptions.Skip<IdentityRole>();
    dbContextMetaDataLoaderOptions.Skip<IdentityRoleClaim<string>>();
    dbContextMetaDataLoaderOptions.Skip<IdentityUser>();
    dbContextMetaDataLoaderOptions.Skip<IdentityUserClaim<string>>();
    dbContextMetaDataLoaderOptions.Skip<IdentityUserLogin<string>>();
    dbContextMetaDataLoaderOptions.Skip<IdentityUserRole<string>>();
    dbContextMetaDataLoaderOptions.Skip<IdentityUserToken<string>>();
}

public static class ApplicationBuilderExtensions
{
    public static void ConfigureMigrations(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}