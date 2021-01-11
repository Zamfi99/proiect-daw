using System;
using DAW_Yacht.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using RAW_Yacht.Areas.Data;

[assembly: HostingStartup(typeof(DAW_Yacht.Areas.Identity.IdentityHostingStartup))]
namespace DAW_Yacht.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                string mySqlConnectionStr = context.Configuration.GetConnectionString("IdentityDataContextConnection");
                services.AddDbContext<IdentityDataContext>(options =>
                    options.UseMySql(
                        mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
                    // options.UseSqlServer(
                    //     context.Configuration.GetConnectionString("IdentityDataContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityDataContext>();
            });
        }
    }
}