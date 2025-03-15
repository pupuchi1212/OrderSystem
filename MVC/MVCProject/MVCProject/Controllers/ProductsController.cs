using MVCProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string _apiBaseUrl;

        public ProductsController()
        {
            _apiBaseUrl = WebConfigurationManager.AppSettings["webapiUrl"];
        }

        public ActionResult Index()
        {
            string url = _apiBaseUrl + "products";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                var products = JsonConvert.DeserializeObject<List<ProductInfo>>(result);
                return View(products);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductInfo product)
        {
            string url = _apiBaseUrl + "products";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(product);
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            string url = _apiBaseUrl + $"products/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                var product = JsonConvert.DeserializeObject<ProductInfo>(result);
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductInfo product)
        {
            string url = _apiBaseUrl + $"products/{product.ProductId}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(product);
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            string url = _apiBaseUrl + $"products/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return RedirectToAction("Index");
            }
        }
    }
}