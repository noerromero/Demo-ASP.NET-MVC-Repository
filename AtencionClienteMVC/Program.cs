using AtencionClienteMVC.Infrastructure.Persistence.InMemory;
using AtencionClienteMVC.Infrastructure.Persistence.SQLite;
using AtencionClienteMVC.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add manually
//builder.Services.AddScoped<ICustomerSupportRepository, InMemoryCustomerSupportRepository>();
builder.Services.AddScoped<ICustomerSupportRepository, SQLiteCustomerSupportRepository>();
builder.Services.AddScoped<IGenderRepository, InMemoryGenderRepository>();
builder.Services.AddScoped<IReasonRepository, InMemoryReasonRepository>();

//add manually
builder.Services.AddDbContext<Context>(x => {
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add manually services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerSupport}/{action=Index}/{id?}");

app.Run();

