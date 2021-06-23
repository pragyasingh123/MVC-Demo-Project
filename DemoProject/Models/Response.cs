using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public enum ResponseCode
    {
        [Description("Success")]
        Ok = 200,

        [Description("Data Not found")]
        DataNotFound = 48,

        [Description("No more trains available on this search criteria")]
        DataNotAvailable = 201,

        [Description("Sorry, we could not find any journeys that match your search. Please check your search information and try again.")]
        SubscriptionDataNotAvailable = 204,

        [Description("Provided email already exists")]
        EmailExists = 50,

        [Description("Your journey is not valid for current scenario, Please choose another ticket combination")]
        JourneyInvalid = 203,

        [Description("Invalid login Details")]
        InvalidLoginDetails = 49,

        [Description("Error")]
        Error = 501,

        [Description("ValidationError")]
        ValidationError = 400
    }
    public class ApiResponse
    {
        public string ResponseMessage { get; set; }
        public short ResponseCode { get; set; }
        public string Error { get; set; }
        public string SessionCode { get; set; }

        public ApiResponse(ResponseCode responseCode, string error = "")
        {
            ResponseCode = (short)responseCode;
            ResponseMessage = responseCode.ToDescriptionString();
            Error = error;
           
        }
    }

    #region ResponseCode Enum Extension
    public static class ResponseExtensions
    {
        public static string ToDescriptionString(this ResponseCode val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
    #endregion
}