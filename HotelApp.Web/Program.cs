using DataAccessLibrary.Data;
using DataAccessLibrary.Databases;

namespace HotelApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            // Creates an item in the dependency injection. Creates an instance each time.
            // This makes that each time the Interface is called, a SqlCrud is passed
            // Is like each time you ask for said interface you get the set class.
            builder.Services.AddTransient<IDatabaseCrud, SqlCrud>();
            builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
