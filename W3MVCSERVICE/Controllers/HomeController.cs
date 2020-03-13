
/*OBTIENE  REGS DE DB2CLOUD Y LAS MUESTRA    AGM 05AG19          */
/*   */
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using W3MVCSERVICE.Models;
using W3MVCSERVICE.Services;

namespace W3MVCSERVICE.Controllers
{
    public class HomeController : Controller
    {
        public IRecVideos RECVIDEOS { get; }
        public HomeController(IRecVideos recvideos)
        {
            RECVIDEOS = recvideos;
        }

        //llama sitio con node.js de bx
        public async Task<IActionResult> Index()
        {

            var videos = RECVIDEOS.ObtenerVideos(); //SERVICIO
            using (var client = new HttpClient())
            {
          //  https://accesa99zdb2.mybluemix.net/recu_db2?vid=P
                var jsonresult = await client.GetStringAsync("http://accesa99zdb2.mybluemix.net/recu_db2?vid=S");
                JsonConvert.PopulateObject(jsonresult, videos);
                //return   Json(videos);
                return View(videos);
            }

        }
        // sin Task & await
        public async Task<IActionResult> Video3()
        {
            var videos = RECVIDEOS.ObtenerVideos(); //SERVICIO
            using (var client = new HttpClient())
            {
                //  https://accesa99zdb2.mybluemix.net/recu_db2?vid=P
                var jsonresult = await  client.GetStringAsync("http://accesa99zdb2.mybluemix.net/recu_db2?vid=S");
              JsonConvert.PopulateObject(jsonresult, videos  );
              return View("Index", videos); //no poner path 
            }

        }


        public async Task<IActionResult> Video2()
        {
            using (var client = new HttpClient())
            {
                var jsonresult = await client.GetStringAsync("http://accesa99zdb2.mybluemix.net/recu_db2?vid=A");
                // ejem:
                string json = @"['Starcraft','Halo','Legend of Zelda']";
                List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);


                //Creating List
                List<Datavid1> videos = new List<Datavid1>();
                //   {
                //Adding records to list
                // new Datavid1 { }
                //     };

                JsonConvert.PopulateObject(jsonresult, videos);

                //return   Json(videos);
                return View("Index", videos); //vista index encontrada
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

