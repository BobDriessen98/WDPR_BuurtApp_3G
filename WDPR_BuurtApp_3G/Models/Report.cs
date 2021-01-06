﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDPR_BuurtApp_3G.Areas.Identity.Data;

namespace WDPR_BuurtApp_3G.Models
{
    public class Report
    {
        public virtual WDPR_BuurtApp_3GUser User { get; set; }
        public string UserID { get; set; }

        public int MeldingID { get; set; }

        public virtual Melding melding { get; set; }

        public String Omschrijving { get; set; }
    }
}
