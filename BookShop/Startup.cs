using BookShop.DataAccess.Data;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace BookShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders() // the .AddDefaultTokenProviders() generates
                .AddEntityFrameworkStores<ApplicationDbContext>();                      //default token. that means that if we use
                                                                                        //options => options.SignIn.RequireConfirmedAccount = true 
                                                                                        //as in the commented section above, then it will generate
                                                                                        //a token that will need to have the account confirmed
                                                                                        //which will be send during registration ( OnPostAsync action method) via e-mail
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration); //using Ioptions in order to map the values from the 
                                                             // appsettings with those from EmailOptions class properties
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //because we Use Areas will need to add the following code in 
            //in order to be able and redirect us.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "3610533632329607";
                options.AppSecret = "8097298ba5c66d6f7ca955a446d215b7";
            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "738963374340-71e3f0642q9kgullgjqd6l8j93bjs45v.apps.googleusercontent.com";
                options.ClientSecret = "wOt31dfHHzpmI9ZzLjw7qUzs";

            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];


            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
