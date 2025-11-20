using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebDev.Authorization;
using WebDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDataAccessLayer(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(configureOptions =>
    {
        configureOptions.LoginPath = "/Login/Register";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizationConventions.PolicyName, policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddMvc(options =>
{
    options.Conventions.Add(new AuthorizationConventions());
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=WelcomePage}/{id?}");

app.Run();
