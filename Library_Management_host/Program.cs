using Library_Management;
using Library_Management.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host1 = new ServiceHost(typeof(StudentService)))
            using (ServiceHost host = new ServiceHost(typeof(BookService)))
            {
                host.Open();
                host1.Open();
                Console.WriteLine("Book service started on http://localhost:8090/ @" + DateTime.Now.ToString());
                Console.WriteLine("Student Service started on http://localhost:8100/ @" + DateTime.Now.ToString());

                Console.ReadLine();
            }
        }
    }
}
