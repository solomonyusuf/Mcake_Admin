using MCake_Manage.Areas.Identity;
using MCake_Manage.Data;
using MCake_Manage.Models;
using MCake_Manage.service;
using MCake_Manage.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace MCake_Manage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                options.UseNpgsql(Configuration.GetConnectionString("PostConnection"))
                );
            services.AddIdentity<IdentityUser, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddEntityFrameworkNpgsql();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<ProductsController>();
            services.AddTransient<ProductCollectionsController>();
            services.AddTransient<CartsController>();
            services.AddTransient<ImagesController>();
            services.AddTransient<CategoriesController>();
            services.AddTransient<BlogsController>();
            services.AddTransient<OrdersController>();
            services.AddTransient<PaysController>();
            services.AddTransient<ContactsController>();
            services.AddTransient<ReviewsController>();
            services.AddTransient<WishlistsController>();
            services.AddTransient<WishCollectionsController>();
            services.AddTransient<ActivitiesController>();
            services.AddTransient<RolesController>();
            services.AddTransient<ApplicationUserController>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager,
          RoleManager<Role> roleManager)
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32302e312e30YmihKEdpJXspNePDbBbA6ddpaKLHGB/RS6Kv8a42H/k=");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            SetupDb.SeedData(userManager, roleManager);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseHsts();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
