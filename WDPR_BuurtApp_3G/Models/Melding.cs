using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Areas.Identity.Data;

namespace WDPR_BuurtApp_3G.Models
{
    public class Melding
    {
        public int MeldingID { get; set; }

        public virtual WDPR_BuurtApp_3GUser User { get; set; }
        public string UserID { get; set; }

        public string Titel { get; set; }

        public int AantalViews { get; set; }

        public string Omschrijving { get; set; }

        public virtual Categorie Categorie { get; set; }

        public int CategorieID { get; set; }
        public DateTime Datum { get; set; }

        public string Foto { get; set; }

        public Boolean Gesloten { get; set; }


        public virtual IList<Reactie> Reacties { get; set; }

        public virtual IList<Like> Likes { get; set; }

        public virtual IList<Report> Reports { get; set; }



    }
}
