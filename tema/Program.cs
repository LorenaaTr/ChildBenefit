using Microsoft.EntityFrameworkCore;
using tema.Data;
using Tema.DataAccess.Repository;
using Tema.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Tema.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;
using tema.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<tema.Services.IEmailSender, tema.Services.EmailSender>();

//Stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));
var key = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");
var app = builder.Build();

app.UseRouting();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

app.Run();
