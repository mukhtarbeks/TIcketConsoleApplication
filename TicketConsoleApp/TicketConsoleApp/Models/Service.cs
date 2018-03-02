using System;
using System.Collections.Generic;
using System.Text;

namespace TicketConsoleApp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ServiceCategory Category { get; set; }
        public int OrganizationId {get;set;}
        public Organization Organization { get; set; }
        public Service()
        {
        }
        public Service(int _id,string _name, ServiceCategory _serviceCategory,int _organizationId)
        {
            this.Id = _id;
            this.Name = _name;
            this.Category = _serviceCategory;
            this.OrganizationId = _organizationId;
        }
    }
}
