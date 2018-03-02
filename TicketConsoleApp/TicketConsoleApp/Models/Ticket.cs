using System;
using System.Collections.Generic;
using System.Text;

namespace TicketConsoleApp.Models
{
    class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
