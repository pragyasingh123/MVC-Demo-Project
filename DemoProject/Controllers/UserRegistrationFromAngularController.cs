using DemoProject.Models;
using DemoProject.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class UserRegistrationFromAngularController : ApiController
    {

        [System.Web.Http.HttpPost]
        public ApiResponse UserRegister(RegisteredUser registeredUser) {

            if (registeredUser != null) {
                Guid newId = Guid.NewGuid();
                registeredUser.Id = newId;


                if (ModelState.IsValid)
                {

                    ShoppingEntities shopping = new ShoppingEntities();
                    shopping.RegisteredUsers.Add(registeredUser);
                    shopping.SaveChanges();
                    return new ApiResponse(ResponseCode.Ok);

                }

            }
            return new ApiResponse(ResponseCode.Error);
        }


        [System.Web.Http.HttpPost]
        public ApiResponse UserLogin(UserData data)
        {

            if (data != null)
            {
               

                if (ModelState.IsValid)
                {


                    using (ShoppingEntities entity = new ShoppingEntities())
                    {
                        var obj = entity.RegisteredUsers.Where(a => a.FirstName.Equals(data.UserName) && a.Password.Equals(data.UserPassword)).FirstOrDefault();
                        if (obj != null)
                        {
                            return new ApiResponse(ResponseCode.Ok);

                        }


                    }
                   
                }

            }
            return new ApiResponse(ResponseCode.Error);
        }

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


    }
}