using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Data;
using PetShop.Reposetory;
using System.Net.Mime;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;

builder.Services.AddDbContext<PetStoreContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalRepository,AnimalsRepository>();// הקוד נותן לתוכנית לדעת ולהחזיר אינסטנס של הקלאס
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 

app.Run();
