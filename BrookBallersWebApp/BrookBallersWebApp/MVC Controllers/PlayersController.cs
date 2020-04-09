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
using System.Globalization;

namespace BrookBallersWebApp.Controllers
{
    public class PlayersController : Controller
    {
        static Uri Uri = new Uri("https://localhost:44383/api/Players");

        // GET: Players
        public async Task<IActionResult> Index(string input)
        {

            TextInfo textInfo = new CultureInfo("en-UK", false).TextInfo;


            using (var client = new HttpClient())
            {
                var jsonPlayers = await client.GetStringAsync(Uri);
                var desaralisedPlayers = JsonConvert.DeserializeObject<List<Player>>(jsonPlayers);

                if (string.IsNullOrEmpty(input))
                {
                    return View(desaralisedPlayers.OrderByDescending(p => p.TGA));
                }

                else
                {
                    return View(desaralisedPlayers.OrderByDescending(p => p.TGA).Where(p => p.PlayerName.Contains(textInfo.ToTitleCase(input))));
                }

            }

        }

        public async Task<IActionResult> GetAssistLeader()
        {
            using (var client = new HttpClient())
            {
                var jsonPlayers = await client.GetStringAsync(Uri);
                var deseralisedPlayers = JsonConvert.DeserializeObject<List<Player>>(jsonPlayers);
                return View(deseralisedPlayers.OrderByDescending(p => p.Assists));
            }
        }

        public async Task<IActionResult> GetTopScorers()
        {
            using (var client = new HttpClient())
            {
                var jsonPlayers = await client.GetStringAsync(Uri);
                var deseralisedPlayers = JsonConvert.DeserializeObject<List<Player>>(jsonPlayers);
                return View(deseralisedPlayers.OrderByDescending(p => p.Goals));
            }
        }

    }
}
