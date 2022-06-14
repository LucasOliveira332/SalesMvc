using Microsoft.EntityFrameworkCore;
using SalesMvc.Data;
using SalesMvc.Models.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesMvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedingService.Initialize(services);
}



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
