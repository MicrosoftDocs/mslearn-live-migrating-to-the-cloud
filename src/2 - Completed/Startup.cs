using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Logging;

namespace RealEstate
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IHostingEnvironment hostingEnv, ILogger<Startup> logger)
		{
			Configuration = configuration;
			_hostingEnv = hostingEnv;
			_logger = logger;
		}

		readonly ILogger _logger;
		readonly IHostingEnvironment _hostingEnv;
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
					.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
					options =>
					{
						options.LoginPath = new PathString("/Login/");
						options.AccessDeniedPath = new PathString("/Forbidden/");
					});

			// setup a policy for Administrators that we can Authorize against
			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
			});


			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			bool shouldUseAzureDbLiveConnection = Environment.GetEnvironmentVariable("UseAzureDBLiveConnection") == "true";
			_logger.LogInformation("Hosting environment name: " + _hostingEnv.EnvironmentName);
			_logger.LogInformation("Hosting environment is development? " + _hostingEnv.IsDevelopment());
			_logger.LogInformation("Hosting environment is production? " + _hostingEnv.IsProduction());
			_logger.LogInformation("Should use Azure DB Live Connection (will only be used if the environment is 'Developer')? " + shouldUseAzureDbLiveConnection);

			// Use the mock data repo if there is no SQL connection string or it seems invalid (does not contain 'Server=").
			var sqlConnectionString = _hostingEnv.IsDevelopment() && shouldUseAzureDbLiveConnection ? Configuration.GetConnectionString("AzureDBLiveConnection") : Configuration.GetConnectionString("DefaultConnection");
			if (string.IsNullOrWhiteSpace(sqlConnectionString) || !sqlConnectionString.ToLowerInvariant().Contains("server="))
			{
				_logger.LogWarning("No database connection string configured! Using mock data respository!");
				services.AddScoped<IDataRepository, MockDataRepository>();
			}
			else
			{
				services.AddDbContext<ApplicationDbContext>(options =>
				{
					options.UseSqlServer(sqlConnectionString);
				});
				services.AddScoped<IDataRepository, EfDataRepository>();
			}

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			// For Uploading images to the servers file system (for single server systems only)
			//var assetsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets");
			//services.AddSingleton<IImageUpload>(new LocalFileImageUpload(assetsFolder, @"/assets/"));

			// For uploading to Azure Blob Storage - configuration for local development is read from appsettings.Development.json and uses a predefined
			// account name and account key as described here: https://docs.microsoft.com/de-de/azure/storage/common/storage-use-emulator#authorize-with-shared-key-credentials
			// Adding scoped so in case config values are changed, they will be picked up
			services.AddScoped<IImageUpload>(provider => new StorageUpload(new StorageUploadConfiguration {
				AccountName = Configuration.GetValue<string>("CloudStorageAccountName"),
				AccountKey = Configuration.GetValue<string>("CloudStorageAccountKey"),
				ContainerName = Configuration.GetValue<string>("CloudStorageBlobContainer"),
				BlobStorageBaseUrl = Configuration.GetValue<string>("CloudStorageBaseUrl")
			}));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc();
		}
	}
}
