using meetup.DLA;
using Microsoft.EntityFrameworkCore;

namespace meetup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<meetupContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            var app = builder.Build();

            app.MapControllerRoute("areas","{area:exists}/{controller=Meet}/{action=Index}/{id?}");
            app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            app.UseFileServer();
            app.Run();
        }
    }
}
