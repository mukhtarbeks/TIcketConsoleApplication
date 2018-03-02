using System;
using System.Collections.Generic;
using System.Text;

namespace TicketConsoleApp.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceCategory()
        {
        }
        public ServiceCategory(int _id, string _name)
        {
            this.Id = _id;
            this.Name = _name;
        }
    }
}
