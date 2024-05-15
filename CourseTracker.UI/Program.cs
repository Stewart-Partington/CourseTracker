using CourseTracker.UI.Services.DAL;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CourseTracker.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.Configure<RazorViewEngineOptions>(
				p => p.ViewLocationExpanders.Add(
					new CustomViewLocationExpander()));

			builder.Services.AddHttpClient<IApiDal, ApiDal>();

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
				pattern: "{controller=Students}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
