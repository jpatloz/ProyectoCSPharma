using DAL.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProyectoCSPharma.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<CspharmaInformacionalContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion")));

builder.Services.AddDbContext<LoginRegisterContext>(
  o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LoginRegisterContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
