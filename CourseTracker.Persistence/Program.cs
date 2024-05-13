using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseTracker.Persistence
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			var services = new ServiceCollection();
			services.AddTransient<IConfiguration>();

			IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
			IConfigurationRoot config = builder.Build();

			//services.AddDbContext<DatabaseService>(options =>
			//	options.UseSqlServer(config.GetConnectionString("SQLConnectionString")));
			services.AddDbContext<DatabaseService>();

		}
	}
}