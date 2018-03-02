using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TicketConsoleApp.Models;

namespace TicketConsoleApp.Controllers
{
    class ServicesController
    {
        public List<Service> serviceList = new List<Service>();
        //public List<ServiceCategory> serviceCategoryList = new List<ServiceCategory>();
        
        public enum Type
        {
            Service,
            Organization,
            ServiceCategory,
            Ticket,
            TicketDetail
        }
        string name;
        public void CreateService(List<ServiceCategory> scl)
        {
            try
            {
                Console.WriteLine("Enter name of service");
                name = Console.ReadLine();
                int id = serviceList.Count + 1;
                int idOrganization = serviceList.Count + 1;
                Console.WriteLine("Choose id of category:");
                foreach (var item in scl)
                {
                    Console.WriteLine("Id : {0} Name: {1} ", item.Id, item.Name);
                }
                int idCategory = Convert.ToInt32(Console.ReadLine());
                ServiceCategory  servCat = scl.Where(x => x.Id == idCategory).FirstOrDefault();
                Service s = new Service(id, name,servCat,idOrganization);
                serviceList.Add(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EditService(int id)
        {
            Service sc = serviceList.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine("Edit Service by ID");
            Console.WriteLine("Old name: " + sc.Name);
            name = Console.ReadLine();
            foreach (Service serv in serviceList)
            {
                if (serv.Id == id)
                {
                    serv.Name = name;
                }
            }
        }
        public void DeleteService(int id)
        {
            serviceList.RemoveAt(id - 1);
        }
        public void GetServiceList()
        {
            foreach (var item in serviceList)
            {
                Console.WriteLine("Id : {0} Name: {1} Category: {2} OrganizationId: {3}", item.Id, item.Name,item.Category.Name,item.OrganizationId);
            }
        }
        public void ServiceCRUD(List<ServiceCategory> listCat)
        {
            bool crud = true;
            string json;
            int id;
            while (crud)
            {
                Console.WriteLine();
                Console.WriteLine("Create new Service enter - 1");
                Console.WriteLine("Edit Service  enter - 2");
                Console.WriteLine("Delete Service enter - 3");
                Console.WriteLine("Exit enter - 4");
                
                Console.WriteLine();
                Console.WriteLine("******* Service List ******");
                GetServiceList();
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.WriteLine();
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        CreateService(listCat);
                        json = JsonConvert.SerializeObject(serviceList);
                        Console.WriteLine(Save(json, Type.Service));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        EditService(id);
                        json = JsonConvert.SerializeObject(serviceList);
                        Console.WriteLine(Save(json, Type.Service));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        DeleteService(id);
                        json = JsonConvert.SerializeObject(serviceList);
                        Console.WriteLine(Save(json, Type.Service));
                        break;
                    case ConsoleKey.D4:
                        crud = false;
                        break;
                }
            }
        }

        public bool Save(string json, Type type)
        {
            try
            {
                string path = type.ToString() + ".txt";

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(json);
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(json);
                        tw.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetJson(Type type)
        {
            try
            {
                using (StreamReader r = new StreamReader(Type.Service.ToString() + ".txt"))
                {
                    string json = r.ReadToEnd();
                    return json;
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
