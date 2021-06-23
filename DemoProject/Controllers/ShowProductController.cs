using DemoProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoProject.Controllers
{
    public class ShowProductController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetProducts(string filterType)
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
                var products = completeData;
                return Ok(new { data = products });
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
