using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace redbus.Pages
{
    [BindProperties]
    public class RedBusModel : PageModel
    {
        public string[] allBus;
        public string Name;
        public DateTime Arrival;
        public string Place;
        public int number;
        public Dictionary<int, BusToGo> htBus = new Dictionary<int, BusToGo>();
        private readonly ILogger<RedBusModel> _logger;

        public RedBusModel(ILogger<RedBusModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            allBus = System.IO.File.ReadAllLines("getbus.txt");
        }
        public void OnPost(string Name, DateTime Arrival, string Place)
        {
            
            htBus.Add(number, new BusToGo(Name, Arrival, Place));
            number++;
            string details = htBus[0].ToString();
            System.IO.File.AppendAllText("getbus.txt", details + Environment.NewLine);
            allBus = System.IO.File.ReadAllLines("getbus.txt");
        }
    }
    public class BusToGo
    {
        public BusToGo() { }  
        public BusToGo(string busName, DateTime busarrival, string destination)
        {
            this.BusName = busName;
            this.BusArrival = busarrival;
            this.Destination = destination;
        }
        public string BusName { get; private set; } 
        public DateTime BusArrival { get; private set; }
        public string Destination { get; private set; }
        public override string ToString()  
        {
            return " Bus Name:" + this.BusName + "\n Arrival Time:" + this.BusArrival + "\n Destination Point:" + this.Destination;
        }

    }

}
