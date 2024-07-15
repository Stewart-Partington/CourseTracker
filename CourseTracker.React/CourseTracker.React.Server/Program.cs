
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;

namespace CourseTracker.React.Server
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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAdvancedDependencyInjection();

            builder.Services.Scan(p => p.FromAssemblies(assemblies)
                .AddClasses()
                .AsMatchingInterface());

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
