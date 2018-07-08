using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplSignalR.SignalR
{
    public class TrajetMessageModel
    {
        public int Id { get; set; }
        public string UpdateAt { get; set; }
        public string Depart { get; set; }
        public string Arrivee { get; set; }
    }
}