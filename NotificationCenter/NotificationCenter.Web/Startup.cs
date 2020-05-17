using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationCenter.Core;
using NotificationCenter.Core.Configuration;
using NotificationCenter.DataAccess.Configuration;
using NotificationCenter.EventGenerator;
using NotificationCenter.SignalR;
using NotificationCenter.SignalR.Configuration;
using NotificationCenter.Web.Services;

namespace NotificationCenter.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
            });

            services.AddSignalR();
            services.AddControllersWithViews()
                .AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            ConfigureAppServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, INotificationEventHandler notificationEventHandler)
        {
            //TODO
            notificationEventHandler.Clear(app.ApplicationServices);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                ConfigureHubs(endpoints);
            });
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddWebSignalR(Configuration);
            services.AddDataAccess(Configuration);
            services.AddCore(Configuration);

            //TODO
            services.AddHostedService<NotificatioHostedService>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<INotificationService, NotificationService>();
        }

        private void ConfigureHubs(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<NotificationHub>("/notificationhub");
        }
    }
}
