using Microsoft.EntityFrameworkCore;
using WebOrderTracker.Areas.Identity.Data;
using WebOrderTracker.Business.Services;
using WebOrderTracker.Common.Constants.WebOrderTracker;
using WebOrderTracker.Data;
using WebOrderTracker.DataLayer.Context;
using WebOrderTracker.DataLayer.Repositories;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Setup fundamental routing architectures
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// builder.Configuration.AddJsonFile("DbConnections.json", optional: false, reloadOnChange: true);

string connectionString = GeneralConstants.RemoteDBConnection;

// 2. Register separate Identity Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Register standard Work Order Tracker Context (Fixed closing parenthesis)
builder.Services.AddDbContext<WoTrackerDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebOrderTracker.DataLayer")));

// 4. FIX: Register Identity Engines cleanly and attach them to ApplicationDbContext
builder.Services.AddDefaultIdentity<WebOrderTrackerUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<ApplicationDbContext>(); // Maps UserManager to Identity tables

//unit f work and service 
builder.Services.AddScoped<IUnitOfWork, WotUnitOfWork>();
builder.Services.AddScoped<WorkOrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 5. FIX: You must add Authentication BEFORE Authorization for login tracking to work
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
