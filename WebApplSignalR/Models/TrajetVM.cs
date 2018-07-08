using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplSignalR.Models
{
    public class TrajetVM
    {
        public int Id { get; set; }
        public string NumeroTrain { get; set; }
        public string GareDepart { get; set; }
        public string GareArrivee { get; set; }
        public Nullable<System.DateTime> DateHeureDepart { get; set; }
        public Nullable<System.DateTime> DateHeureArrivee { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}