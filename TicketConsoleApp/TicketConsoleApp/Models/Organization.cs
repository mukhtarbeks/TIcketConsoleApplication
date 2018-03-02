using System.Collections.Generic;

namespace TicketConsoleApp.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Service> ServiceList { get; set; }
    }
}