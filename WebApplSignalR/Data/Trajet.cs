//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplSignalR.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trajet
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