using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Areas.Identity.Data;
using WDPR_BuurtApp_3G.Data;
using WDPR_BuurtApp_3G.Models;

namespace WDPR_BuurtApp_3G
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
            services.AddControllersWithViews();

            services.AddDbContext<WDPR_BuurtApp_3GContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("WDPR_BuurtApp_3GContextConnectionGezamenlijk"), ServerVersion.FromString("8.0.22-mysql")).UseLazyLoadingProxies());
            services.AddRazorPages();
            services.AddDefaultIdentity<WDPR_BuurtApp_3GUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WDPR_BuurtApp_3GContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //Aanroepen van de methode om rollen aan te maken
            //CreateRoles(serviceProvider).Wait();
            //AddToModerator(serviceProvider).Wait();


            
        }
        //Rollen worden aangemaakt indien deze niet aanwezig zijn.
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //String met rollen die moeten worden aangemaakt
            string[] roleNames = { "Moderator", "Gebruiker"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //Controle of de rol die op dit moment wordt doorgelopen bestaat
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //Rol aanmaken
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

        }

        private async Task AddToModerator(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<WDPR_BuurtApp_3GUser>>();

            //Lijst van UserID's die Moderator zijn/moeten worden
            string[] userIDs = { "33eaec00-3b46-47f8-8621-53654eeacc4c" };
            IdentityResult addToRoleResult;
            foreach(var userID in userIDs)
            {
                //Controle of user in de array userIDs al moderator is
                WDPR_BuurtApp_3GUser user = await UserManager.FindByIdAsync(userID);
                var userIsModerator = await UserManager.IsInRoleAsync(user, "Moderator");
                //Maak user moderator indien nog geen moderator
                if (!userIsModerator)
                {
                    addToRoleResult = await UserManager.AddToRoleAsync(user, "Moderator");
                }
            }
        }
    }
}
