using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace JESUSFORUMS
{
    public class Program
    {
        //public ApplicationDbContext CreateDbContext(string[] args)
        //{
        //
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    builder.UseSqlServer(connectionString);
        //    return new ApplicationDbContext();
        //}
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }
        
            public static IWebHost CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseDefaultServiceProvider(options=> options.ValidateScopes = false)
                    .Build(); 
    }
}

