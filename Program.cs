using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Booking_Exam.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("LocalMySQL");
MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
builder.Services.AddDbContext<DataContext>(option =>
    option.UseMySql(connectionString, ServerVersion.AutoDetect(mySqlConnection)));
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();