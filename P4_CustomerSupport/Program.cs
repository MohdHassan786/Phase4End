using Microsoft.EntityFrameworkCore;
using P4_CustomerSupport.Models;



WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BankAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cust")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
