using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TicketConsoleApp.Controllers;
using TicketConsoleApp.Models;

namespace TicketConsoleApp
{
    class Program
    {
        public static CategoriesController cc = new CategoriesController();
        public static ServicesController sc = new ServicesController();
        static void Main(string[] args)
        {
            string s = cc.GetJson(CategoriesController.Type.ServiceCategory);
            string c = sc.GetJson(ServicesController.Type.Service);
            if (s != null)
            {
                cc.ServiceCategoryList = JsonConvert.DeserializeObject<List<ServiceCategory>>(s);
            }
            if (c != null)
            {
                sc.serviceList = JsonConvert.DeserializeObject<List<Service>>(c);
            }
            bool ok = true;
            while (ok)
            {
                Console.WriteLine("Category or Service| 0 or 1");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == 0)
                {
                    cc.ServiceCategoryCRUD();
                }
                else if (n == 1)
                {
                    sc.ServiceCRUD(cc.ServiceCategoryList);
                }
                else
                {
                    ok = false;
                    break;
                }
            }
            

            //Console.ReadKey();
        }
    }
}
