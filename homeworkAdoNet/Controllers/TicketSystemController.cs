using homeworkAdoNet.Models;
using homeworkAdoNet.Services;
using homeworkAdoNet.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace homeworkAdoNet.Controllers
{
    public class TicketSystemController : Controller
    {
        private TicketSystemServices _ticketSystemServices;

        public TicketSystemController()
        {
            _ticketSystemServices = new TicketSystemServices(new DbWorker());
        }

        public IActionResult GetTickes()
        {
            var ticket = _ticketSystemServices.GetTicket();
           return Content(JsonSerializer.Serialize(ticket, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic) }));

        }

        public IActionResult AddTicket(Ticket_ ticket_)
        {
            _ticketSystemServices.AddTicket(ticket_);
            return Content("Билет был добавлен успешно");
        }
    }
}
