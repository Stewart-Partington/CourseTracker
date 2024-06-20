
using CourseTracker.API.Filters;
using CourseTracker.API.Services.AutoMapper;
using System.Runtime.Loader;

namespace CourseTracker.API
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "CourseTracker*.dll");

			var assemblies = files
				.Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers(options =>
			{
				options.Filters.Add(typeof(ExceptionFilter));
			}
			);
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddAdvancedDependencyInjection();

			builder.Services.Scan(p => p.FromAssemblies(assemblies)
				.AddClasses()
				.AsMatchingInterface());

			var app = builder.Build();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseTracker API V1");
			});

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.UseAdvancedDependencyInjection();

			app.Run();
		}
	}
}
