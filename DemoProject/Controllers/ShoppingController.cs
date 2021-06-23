
using DemoProject.Models;
using DemoProject.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
   
    public class ShoppingController : Controller
    {
        // GET: Shopping

       
        public ActionResult ShowListing()
        {
            List<ItemMst> listing = new List<ItemMst>();
            ShoppingEntities entity = new ShoppingEntities();
            listing = entity.ItemMsts.ToList();

            return View(listing);
        }


        public ActionResult ShowProductItem() {
            WebResponse response;
            List<ApiModel> completeData = new List<ApiModel>();
            try
            {
                var apiUrl = ConfigurationManager.AppSettings["ProductsUrl"];
                var webrequest = WebRequest.Create(apiUrl);
                response = webrequest.GetResponse();
                string result = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                if (result != string.Empty)
                {
                    completeData = JsonConvert.DeserializeObject<List<ApiModel>>(result);
                }

                Log.Info("Api has been executed");
            }
            catch (Exception ex) {
                Log.Error("ShowProductItem", ex);
            }
           

            return View(completeData);
        }

        
        [HttpGet]
        public JsonResult GetSpecificItem(string filterType) {
            WebResponse response;
            var data = filterType.Split('|');
            List<ApiModel> completeData = new List<ApiModel>();
            List<ApiModel> filteredData = new List<ApiModel>();
            try
            {
                var apiUrl = ConfigurationManager.AppSettings["ProductsUrl"];
                var webrequest = WebRequest.Create(apiUrl);
                response = webrequest.GetResponse();
                string result = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                if (result != string.Empty)
                {
                    completeData = JsonConvert.DeserializeObject<List<ApiModel>>(result);
                }
                foreach (var filter in data) {
                    if (filter != string.Empty) {
                   var datafiltered=  completeData.Where(a => a.Category.Equals(filter)).ToList();
                     filteredData.AddRange(datafiltered);
                    }
                }
               

                Log.Info("Api has been executed");
            }
            catch (Exception ex)
            {
                Log.Error("ShowProductItem", ex);
            }


            return Json(new { data = filteredData, totalItems = filteredData.Count }, JsonRequestBehavior.AllowGet);
        }

    }
}