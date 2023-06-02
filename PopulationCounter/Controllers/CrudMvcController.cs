using PopulationCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PopulationCounter.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: CrudMvc
        public ActionResult Index()
        {
            List<Family> familyList = new List<Family>();
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.GetAsync("FirstApi");
            response.Wait();

            var test = response.Result;

            if(test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<List<Family>>();
                display.Wait();
                familyList = display.Result;
            }


            return View(familyList);
        }

        public ActionResult Details(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.GetAsync("FirstApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        // get details by pincode
        public ActionResult DetailsByPincode(int pin)
        {
            List<Family> familyListByPincode = new List<Family>();
            client.BaseAddress = new Uri("https://localhost:44367/api/SecondApi");

            var response = client.GetAsync("SecondApi?pin=" + pin.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<List<Family>>();
                display.Wait();
                familyListByPincode = display.Result;
            }

            return View(familyListByPincode);
        }

        // get details by village
        public ActionResult DetailsByVillage(string vil)
        {
            List<Family> familyListByPincode = new List<Family>();
            client.BaseAddress = new Uri("https://localhost:44367/api/SecondApi");

            var response = client.GetAsync("SecondApi?vil=" + vil);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<List<Family>>();
                display.Wait();
                familyListByPincode = display.Result;
            }

            return View(familyListByPincode);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Family fam)
        {
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.PostAsJsonAsync<Family>("FirstApi",fam);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.GetAsync("FirstApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Family f)
        {
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.PutAsJsonAsync<Family>("FirstApi", f);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.GetAsync("FirstApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44367/api/FirstApi");

            var response = client.DeleteAsync("FirstApi/" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }

        
    }
  
}