using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Areas.Identity.Data;

namespace WDPR_BuurtApp_3G.Models
{
    public class Vote
    {
        public string UserID { get; set; }

        public virtual WDPR_BuurtApp_3GUser User { get; set; }

        public int ReactieID { get; set; }

        public virtual Reactie Reactie { get; set; }
    }
}
