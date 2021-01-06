using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR_BuurtApp_3G.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }

        public string Naam { get; set; }

        public virtual IList<Melding> Meldingen {get; set;}
    }
}
