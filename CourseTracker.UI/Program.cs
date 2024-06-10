using CourseTracker.UI.Services.AutoMapper;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using CourseTracker.UI.Shared.Filters;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;

namespace CourseTracker.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews(options =>
				{
					options.Filters.Add(typeof(ExceptionFilter));
				}
			)
				.AddRazorRuntimeCompilation();
			builder.Services.Configure<RazorViewEngineOptions>(
				p => p.ViewLocationExpanders.Add(
					new CustomViewLocationExpander()));

			builder.Services.AddHttpClient<IApiDal, ApiDal>();
			builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddScoped<IState, SessionState>();

			#region Localization

			builder.Services.Configure<RequestLocalizationOptions>(options =>
			{
				options.SupportedCultures = new List<CultureInfo>
				{
					new CultureInfo("en-CA")
				};
				options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-CA");
			});
            CultureInfo cultureInfo = new CultureInfo("en-CA");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            IMvcBuilder mvcBuilder = builder.Services.AddMvc();
			mvcBuilder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
				options =>
				{
					options.ResourcesPath = "Shared.Resources";
				})
				.AddDataAnnotationsLocalization();

			builder.Services.Configure<LocalizationOptions>(options =>
			{
				options.ResourcesPath = "Shared.Resources";
			});

            #endregion

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
			app.UseSession();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Students}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
