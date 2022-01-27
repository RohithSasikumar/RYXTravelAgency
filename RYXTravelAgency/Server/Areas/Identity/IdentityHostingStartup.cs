using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RYXTravelAgency.Server.Data;
using RYXTravelAgency.Server.Models;

[assembly: HostingStartup(typeof(RYXTravelAgency.Server.Areas.Identity.IdentityHostingStartup))]
namespace RYXTravelAgency.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}