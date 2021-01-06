using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WDPR_BuurtApp_3G.Models;

namespace WDPR_BuurtApp_3G.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WDPR_BuurtApp_3GUser class
    public class WDPR_BuurtApp_3GUser : IdentityUser
    {
        [PersonalData]
        public string Voornaam { get; set; }
        [PersonalData]
        public string Achternaam { get; set; }
        [PersonalData]
        public string Adres { get; set; }
        [PersonalData]
        public string Foto { get; set; }

        public virtual IList<Reactie> Reacties { get; set; }

        public virtual IList<Like> Likes { get; set; }

        public virtual IList<Report> Reports { get; set; } 

        public virtual IList<Melding> Meldingen { get; set; } 

    }
}
