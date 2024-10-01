using CRUDAppUsingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUDAppUsingWebAPI.Controllers
{
    public class ExpancesController : Controller
    {
     private   string url = "https://localhost:7070/api/DailyExpances/";
        private HttpClient httpClient =new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Expances> expances = new List<Expances>();
            HttpResponseMessage message = httpClient.GetAsync(url).Result;
            if (message.IsSuccessStatusCode) 
            { 
            string res= message.Content.ReadAsStringAsync().Result;
                var data= JsonConvert.DeserializeObject<List<Expances>>(res);
                if(data != null )
                {
                    expances= data;
                }
            }
            return View(expances);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Expances ex)
            
        {
            var data= JsonConvert.SerializeObject(ex);
            StringContent stringContent = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage message= httpClient.PostAsync(url, stringContent).Result;
            if(message.IsSuccessStatusCode)
               
            {
                TempData["message"] = "data added;";
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)

        {
            Expances ex=new Expances();
            HttpResponseMessage message = httpClient.GetAsync(url+id).Result;
            if (message.IsSuccessStatusCode)
            {
                string res = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Expances>(res);
                if (data != null)
                {
                    ex = data;
                }
            }
            return View(ex);
        }

        [HttpPost]
        public IActionResult Edit(Expances ex)

        {
            var data = JsonConvert.SerializeObject(ex);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage message = httpClient.PutAsync(url+ex.id, stringContent).Result;
            if (message.IsSuccessStatusCode)

            {
                TempData["message_update"] = "data Updated;";
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)

        {
            Expances ex = new Expances();
            HttpResponseMessage message = httpClient.GetAsync(url + id).Result;
            if (message.IsSuccessStatusCode)
            {
                string res = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Expances>(res);
                if (data != null)
                {
                    ex = data;
                }
            }
            return View(ex);
        }
        [HttpGet]
        public IActionResult Delete(int id)

        {
            Expances ex = new Expances();
            HttpResponseMessage message = httpClient.GetAsync(url + id).Result;
            if (message.IsSuccessStatusCode)
            {
                string res = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Expances>(res);
                if (data != null)
                {
                    ex = data;
                }
            }
            return View(ex);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage message = httpClient.DeleteAsync(url + id).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["message_Delete"] = "data deleted;";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
