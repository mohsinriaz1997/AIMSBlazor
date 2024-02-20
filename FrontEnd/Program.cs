using Blazored.LocalStorage;
using CA.UI.Data.AdministrationData;
using CA.UI.Data.MasterData;
using FrontEnd;
using FrontEnd.Data;
using FrontEnd.Data.MasterData;
using FrontEnd.Interface.MasterData;
using FrontEnd.Interfaces.AdministrationData;
using FrontEnd.Interfaces.MasterData;
using MudBlazor;
using MudBlazor.Services;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IActivityType, MstActivityTypeService>();
builder.Services.AddTransient<IResourceMasterData, MstResourceService>();
builder.Services.AddScoped<IDepartmenMastert, MstDepartmentService>();
builder.Services.AddScoped<IUserProfile, MstUserProfileService>();
builder.Services.AddScoped<IDesignationMaster, MstDesignationService>();
builder.Services.AddSingleton<RestClient>();
builder.Services.AddBlazoredLocalStorage(); // Add this line

Settings.APIBaseURL = builder.Configuration.GetValue<string>("APIBaseUrl");
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});



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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
