using GiphyAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace GiphyAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //api key
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIkey"];
            //search query
            string query = "funny cats";
            //offset
            string offset = "1";
            //Create API request
            WebRequest request = WebRequest.Create($"http://api.giphy.com/v1/gifs/search?q={query}&apikey={apiKey}&offset={offset}");
            //Sends request
            WebResponse response = request.GetResponse();
            //Retrieve data stream
            Stream stream = response.GetResponseStream();
            //Makes stream accessible
            StreamReader reader = new StreamReader(stream);
            //Cast into String
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            //mapping into c# 
            Gif myGifs = parsedString.ToObject<Gif>();
            
            return View(myGifs);

        }  
    }
}