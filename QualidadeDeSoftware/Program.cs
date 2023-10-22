using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("QualidadeDeSoftwareContext")
            ?? throw new InvalidOperationException("Connection string 'QualidadeDeSoftwareContext' not found.");

        builder.Services.AddDbContext<QualidadeDeSoftwareContext>(options =>
            options.UseSqlite(connectionString));

        // Add services to the container.
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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<QualidadeDeSoftwareContext>();
            dataContext.Database.Migrate();
        }
        app.Run();
    }
}