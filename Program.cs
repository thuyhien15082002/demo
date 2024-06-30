using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("fr-FR"),
    new CultureInfo("es-ES"),
    // Add more cultures as needed
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // Optionally, you can add more request culture providers.
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var localizationOptions = app.Services.GetService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>()?.Value;
if (localizationOptions != null)
{
    app.UseRequestLocalization(localizationOptions);
}

app.UseAuthorization();

app.MapRazorPages();

app.Run();
