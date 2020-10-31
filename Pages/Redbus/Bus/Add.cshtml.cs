using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        private readonly ILogger<RedBusModel> _logger;

        public RedBusModel(ILogger<RedBusModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
        public void OnPost(string Name, DateTime Arrival, string Place)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=RedBus;Integrated Security=True");
            connection.Open();
            string querystring = "INSERT INTO BUS(Busname,Busarrival, Destination) VALUES('" + Name + "','" + Arrival + "','" + Place + "')";
            SqlCommand command = new SqlCommand(querystring, connection);
            command.ExecuteNonQuery();

        }
    }
}
