using biaks.Data;
using biaks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	if (!context.Products.Any()) {
		context.Products.AddRange(
			new Product { Name = "Gaming Laptop ASUS", Price = 1299.99m },
			new Product { Name = "Wireless Mouse Logitech", Price = 49.50m },
			new Product { Name = "Mechanical Keyboard Razer", Price = 110.00m },
			new Product { Name = "4K Monitor Samsung", Price = 349.00m },
			new Product { Name = "USB-C Hub", Price = 25.99m },
			new Product { Name = "External SSD 1TB", Price = 89.99m },
			new Product { Name = "Noise Cancelling Headphones", Price = 199.00m },
			new Product { Name = "Webcam 1080p", Price = 59.99m },
			new Product { Name = "Gaming Chair", Price = 250.00m },
			new Product { Name = "Desk Mat XXL", Price = 19.99m }
		);
		context.SaveChanges();
	}
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
