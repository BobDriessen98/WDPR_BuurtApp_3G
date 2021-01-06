using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDPR_BuurtApp_3G.Areas.Identity.Data;

namespace WDPR_BuurtApp_3G.Data
{
    public class WDPR_BuurtApp_3GContext : IdentityDbContext<WDPR_BuurtApp_3GUser>
    {
        public WDPR_BuurtApp_3GContext(DbContextOptions<WDPR_BuurtApp_3GContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Like>().HasKey(l => new { l.UserID, l.MeldingID });
            builder.Entity<Reactie>().HasKey(r => new { r.UserID, r.MeldingID });
            builder.Entity<Report>().HasKey(r => new { r.UserID, r.MeldingID });
            builder.Entity<Vote>().HasKey(r => new { r.UserID, r.ReactieID });

        }

            public DbSet<WDPR_BuurtApp_3G.Models.Melding> Melding { get; set; }

            public DbSet<WDPR_BuurtApp_3G.Models.Reactie> Reactie { get; set; }

            public DbSet<WDPR_BuurtApp_3G.Models.Like> Like { get; set; }

            public DbSet<WDPR_BuurtApp_3G.Models.Report> Report { get; set; }

            public DbSet<WDPR_BuurtApp_3G.Models.Categorie> Categorie { get; set; }

            public DbSet<WDPR_BuurtApp_3G.Models.Vote> Vote { get; set; }
    }
    
}
