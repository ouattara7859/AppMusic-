using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    public class UserController : Controller
    {
        public List<Tracks> tranksElements = new List<Tracks>() { };
        public List<TracksTops> tranksTops = new List<TracksTops>() { };
        private readonly UsersContext _context;

        public UserController(UsersContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("role");
            if (role == "admin"){
                ViewData["role"] = role;
            }
           
            return View();
        }
        public IActionResult User()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> User([Bind("Names")] Name name)
        {

            string n = name.Names;
            var listTracks = await searchTracks(n);
            if(listTracks == null) {
                return View(new List<Tracks>() );
            }
            return View(listTracks);

        }
        public async Task<List<Tracks>> searchTracks(string nameTileOrAlbum)
        {
            string artistOrAlbum = "albums";

            string page = "https://api.jamendo.com/v3.0/" + artistOrAlbum + "/tracks/?client_id=3308fc5f&format=jsonpretty&limit=1&artist_name=" + nameTileOrAlbum;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();
                JObject resultObj = JObject.Parse(result);

                if (result != null)
                {
                    var results = JArray.Parse(resultObj["results"].ToString());

                    if (results.Count()!=0)
                    {
                        var firstElementResult = results[0];
                        
                        var tranks = JArray.Parse(firstElementResult["tracks"].ToString());
                        foreach (var pistes in tranks)

                        {
                            var track = new Tracks()
                            {
                                Id = pistes["id"].ToString(),
                                Position = pistes["position"].ToString(),
                                Name = pistes["name"].ToString(),
                                Duration = pistes["duration"].ToString(),
                                License_ccurl = pistes["license_ccurl"].ToString(),
                                Audio = pistes["audio"].ToString(),
                                Audiodownload = pistes["audiodownload"].ToString(),

                            };
                            tranksElements.Add(track);


                        }
                    }
                    else
                    {

                        ModelState.AddModelError("Error", "already existing email in the database");
                    }



                }
            }
            return tranksElements;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlayList([Bind ("Name ,Audio")] PlayInfo p)
        {

            if (ModelState.IsValid)
            {
                //var data = infos.Split();
                string audioStreaming = p.Audio;
                string titlesAudio = p.Name;
                DateTime date1 = DateTime.Now;
                string email = HttpContext.Session.GetString("EmailSession");

                PlayListModel playList = new PlayListModel()
                {
                    AudioStream = audioStreaming,
                    titleAudio = titlesAudio,
                    DateToAdd = date1,
                    Email = email

                };
                _context.Add(playList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();

        }

        public  async Task<IActionResult> DisplayMostListenedMusics()
        {
            string page = "https://api.jamendo.com/v3.0/tracks/?client_id=3308fc5f&format=jsonpretty&boost=listens_week&limit=10";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();
                JObject resultObj = JObject.Parse(result);

                if (result != null)
                {
                    var results = JArray.Parse(resultObj["results"].ToString());

                    if (results != null)
                    {
                        
                        foreach (var pistes in results)

                        {
                            var track = new TracksTops()
                            {
                                Id = pistes["id"].ToString(),
                                Name = pistes["name"].ToString(),
                                Position = pistes["position"].ToString(),
                                Duration = pistes["duration"].ToString(),
                                Artist_id = pistes["artist_id"].ToString(),
                                Artist_name = pistes["artist_name"].ToString(),
                                Artist_idstr = pistes["artist_idstr"].ToString(),
                                Album_name = pistes["album_name"].ToString(),
                                Album_Image= pistes["album_image"].ToString(),
                                Albums_id = pistes["album_id"].ToString(),
                                Releasedate = pistes["releasedate"].ToString(),      
                                License_ccurl = pistes["license_ccurl"].ToString(),
                                Audio = pistes["audio"].ToString(),
                                Audiodownload = pistes["audiodownload"].ToString(),

                            };

                            tranksTops.Add(track);
                            ;
                           //_context.Add(track);
                         
                            await _context.SaveChangesAsync();
                        }

                        return View(tranksTops);
                    }
                }
            }
            return View();
        }
    }
}