using homeworkAdoNet.Models;
using homeworkAdoNet.Utils;
using System.Reflection.Metadata.Ecma335;

namespace homeworkAdoNet.Services
{
    public class TicketSystemServices
    {
        private DbWorker _db;

        public TicketSystemServices(DbWorker db)
        {
            _db = db;
        }

        public IEnumerable<Ticket_> GetTicket()
        {
            return _db.GetTickets();
        }

        public void AddTicket(Ticket_ ticket_)
        {
            _db.AddTicket(ticket_);
        }
    }
}
