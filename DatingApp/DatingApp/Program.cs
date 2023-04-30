using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DatingApp.Interfaces;
using DatingApp.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

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

static void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();


    // add custom services
    // change contactserivce to contactservicetesting to test the testing service

    
    services.AddTransient<ICreateUser, CreateUser>();
    services.AddTransient<IUserExist, UserExist>();
    services.AddTransient<IUserLogin, UserLogin>();
    services.AddTransient<IHashing, Hashing>();
    services.AddTransient<IGetId, GetId>();
    services.AddTransient<IUpdateProfile, UpdateProfile>();
    services.AddTransient<IGetUserProfile, GetUserProfile>();
    services.AddTransient<IGetCity, GetCity>();
    services.AddTransient<IGetGender, GetGender>();


}