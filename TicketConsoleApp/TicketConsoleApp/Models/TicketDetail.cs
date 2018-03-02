using System;
using System.Collections.Generic;
using System.Text;

namespace TicketConsoleApp.Models
{
    class TicketDetail
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public List<int> ServiceIdList { get; set; }
        public List<Service> ServiceList { get; set; }
    }
}
