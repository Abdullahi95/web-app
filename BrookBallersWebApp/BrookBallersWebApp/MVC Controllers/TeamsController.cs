using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrookBallersWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace BrookBallersWebApp.Controllers
{
    public class TeamsController : Controller
    {
        static Uri Uri = new Uri("https://localhost:44383/api/Teams");

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonTeams = await client.GetStringAsync(Uri);
                var deserialisedTeams = JsonConvert.DeserializeObject<List<Team>>(jsonTeams);
                return View(deserialisedTeams.OrderByDescending(t => t.PTS).ThenByDescending(t => t.GD));
            }
        }
    }
}
