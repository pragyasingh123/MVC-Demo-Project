using DemoProject.Models;
using DemoProject.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class UserDataFeedController : ApiController
    {
        // GET: UserDataFeed

        [System.Web.Http.HttpGet]
        public List<ApiModel> ShowProductItem()
        {
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
            catch (Exception ex)
            {
                Log.Error("ShowProductItem", ex);
            }


            return completeData;
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage UserRegistrationFromAngular(RegisteredUser userData)
        {

            Guid newId = Guid.NewGuid();
            userData.Id = newId;


         

            try
            {
                if (ModelState.IsValid)
                {

                    ShoppingEntities shopping = new ShoppingEntities();
                    shopping.RegisteredUsers.Add(userData);
                    shopping.SaveChanges();


                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


    }
}