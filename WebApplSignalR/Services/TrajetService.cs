using System;
using System.Collections.Generic;
using System.Linq;
using WebApplSignalR.Data;

namespace WebApplSignalR.Services
{
    public class TrajetService
    {
        private readonly SignalRDbEntities _context;

        public TrajetService(SignalRDbEntities context)
        {
            _context = context;
        }

        public IList<Trajet> GetTrajets()
        {
            return _context.Trajet.ToList();
        }

        public Trajet GetTrajetById(int id)
        {
            return _context.Trajet.FirstOrDefault(x => x.Id == id);
        }

        public Trajet UpdateTrajet(Trajet trajet)
        {
            if (trajet == null)
            {
                throw new ArgumentNullException(nameof(trajet));
            }

            var trajetToUpdate = GetTrajetById(trajet.Id);
            if (trajetToUpdate != null)
            {
                trajetToUpdate.UpdatedAt = DateTime.Now;
                trajetToUpdate.DateHeureDepart = trajet.DateHeureDepart;
                trajetToUpdate.DateHeureArrivee = trajet.DateHeureArrivee;

                _context.SaveChanges();

                TrajetHub.NotifyAllClients(new SignalR.TrajetMessageModel
                {
                    Id = trajetToUpdate.Id,
                    UpdateAt = trajetToUpdate.UpdatedAt?.ToString(),
                    Depart = trajetToUpdate.DateHeureDepart?.ToString(),
                    Arrivee = trajetToUpdate.DateHeureArrivee?.ToString()
                });
            }

            return trajetToUpdate;
        }

    }
}