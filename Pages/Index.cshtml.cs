using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace redbus.Pages
{
    public class IndexModel : PageModel
    {
        public string[] allTask;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            allTask=System.IO.File.ReadAllLines("dotasks.txt");
        }
        public void OnPost()
        {
           string task=Request.Form["dolist"];
           System.IO.File.AppendAllText("dotasks.txt",task+Environment.NewLine);
           allTask=System.IO.File.ReadAllLines("dotasks.txt");
           
        }
    }
}
