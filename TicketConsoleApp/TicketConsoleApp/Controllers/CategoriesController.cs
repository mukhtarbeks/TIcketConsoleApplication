using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TicketConsoleApp.Models;

namespace TicketConsoleApp.Controllers
{
    class CategoriesController
    {
        public List<ServiceCategory> ServiceCategoryList = new List<ServiceCategory>();
        public enum Type
        {
            Service,
            Organization,
            ServiceCategory,
            Ticket,
            TicketDetail
        }
        string name;
        public void CreateServiceCategory()
        {
            try
            {
                Console.WriteLine("Enter name of category");
                name = Console.ReadLine();
                int id = ServiceCategoryList.Count + 1;
                ServiceCategory sc = new ServiceCategory(id, name);
                ServiceCategoryList.Add(sc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EditServiceCategory(int id)
        {
            ServiceCategory sc = ServiceCategoryList.Where(x => x.Id ==id).FirstOrDefault();
            Console.WriteLine("Edit Category by ID");
            Console.WriteLine("Old name: " + sc.Name);
            name = Console.ReadLine();
            foreach (ServiceCategory servcat in ServiceCategoryList)
            {
                if (servcat.Id == id)
                {
                    servcat.Name = name;
                }
            }  
        }
        public void DeleteServiceCategory(int id)
        {
            ServiceCategoryList.RemoveAt(id-1);
        }
        public void GetServiceCategoryList()
        {
            foreach (var item in ServiceCategoryList    )
            {
                Console.WriteLine("Id : {0} Name: {1} ",item.Id,item.Name);
            }
        }
        public void ServiceCategoryCRUD()
        {
            bool crud = true;
            string json;
            int id;
            while (crud)
            {
                Console.WriteLine();
                Console.WriteLine("Create new Service Category enter - 1");
                Console.WriteLine("Edit Service Category enter - 2");
                Console.WriteLine("Delete Service Category enter - 3");
                Console.WriteLine("Exit enter - 4");
                Console.WriteLine();
                Console.WriteLine("******* Service Category List ******");
                GetServiceCategoryList();
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.WriteLine();
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        CreateServiceCategory();
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        EditServiceCategory(id);
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        DeleteServiceCategory(id);
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
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
                using (StreamReader r = new StreamReader(Type.ServiceCategory.ToString() + ".txt"))
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
