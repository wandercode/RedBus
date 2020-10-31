using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace redbus.Pages
{
    [BindProperties]
    public class BusListModel : PageModel
    {
        public string[] allBus;
        //public List<Bus> BusList { get; set; }
        public List<Bus> BusList = new List<Bus>();
        public string Name;
        public DateTime Arrival;
        public string Place;
        public int number;
        private readonly ILogger<BusListModel> _logger;

        public BusListModel(ILogger<BusListModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=RedBus;Integrated Security=True");
            connection.Open();
            //List<Bus> BusList = new List<Bus>();
            SqlCommand command = new SqlCommand("select * from Bus", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BusList.Add(new Bus(reader.GetString(1),reader.GetDateTime(2),reader.GetString(3)));
                /*Bus prod = new Bus();
                prod.BusName = reader.GetString(0);
                prod.BusArrival = reader.GetDateTime(1);
                prod.Destination = reader.GetString(1);
                List.Add(Bus);*/
            }
            string test=BusList[0].Destination;
            
        }
        public void OnPost(string Name, DateTime Arrival, string Place)
        {

           /* BusList.Add(number, new BusToGo(Name, Arrival, Place));
            number++;
            string details = JsonConvert.SerializeObject(BusList);
            System.IO.File.AppendAllText("getbus.txt", details + Environment.NewLine);
            allBus = System.IO.File.ReadAllLines("getbus.txt");*/
        }
        
    }
    public class Bus
    {
        public Bus() { }
        public Bus(string busName, DateTime busarrival, string destination)
        {
            this.BusName = busName;
            this.BusArrival = busarrival;
            this.Destination = destination;
        }
        public string BusName { get;  set; }
        public DateTime BusArrival { get;  set; }
        public string Destination { get;  set; }
        public override string ToString()
        {
            return " Bus Name:" + this.BusName + "\n Arrival Time:" + this.BusArrival + "\n Destination Point:" + this.Destination;
        }

    }
}