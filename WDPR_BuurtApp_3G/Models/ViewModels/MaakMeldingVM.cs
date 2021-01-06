using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Areas.Identity.Data;
using WDPR_BuurtApp_3G.Models;

namespace WDPR_BuurtApp_3G.Models

    //Viewmodel die wordt gebruikt om melding aan te maken
{
    public class MaakMeldingVM
    {
        public List<Categorie> Categories { get; set; }
        public int MeldingID { get; set; }

        public string Titel { get; set; } 

        public string UserID { get; set; }

        public WDPR_BuurtApp_3GUser user { get; set; }

        public string Omschrijving { get; set; }

        public Categorie Categorie { get; set; }

        public int CategorieID { get; set; }

        public DateTime Datum { get; set; }

        public string Foto { get; set; }

        public Boolean Gesloten { get; set; }

        public virtual IList<Reactie> Reacties { get; set; }

        public virtual IList<Like> Likes { get; set; }

        public virtual IList<Report> Reports { get; set; }
    }
}
