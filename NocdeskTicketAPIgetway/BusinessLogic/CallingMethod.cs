using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NocdeskTicketAPIgetway.Model;
using OwnYITCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NocdeskTicketAPIgetway.BusinessLogic
{
    public class CallingMethod
    {
        [HttpPost]
        public static async Task<string> post_method(string baseUrl, ParameterJSON common)
        {
            string result = "";
            try
            {
                HttpResponseMessage httpResponse = new HttpResponseMessage();
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpResponse = await httpClient.PostAsJsonAsync(baseUrl, common);
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            result = httpResponse.Content.ReadAsStringAsync().Result;
                        }
                        if (result == "")
                        {
                            result = "401 Unauthorized";
                        }
                    }
                }
                //}
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public static async Task<string> post_method_data(string baseUrl, ParameterJSON UserCommon)
        {
            string result = "";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpResponse = await httpClient.PostAsJsonAsync(baseUrl, UserCommon);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        result = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                    if (result == "")
                    {
                        result = "401 Unauthorized";
                    }
                }
            }
            return result;
        }
        internal static string SetOwnyitV4URL()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public static string post_method2(string baseUrl, TicketMaster common)
        {
            string result = "";
            try
            {
                HttpResponseMessage httpResponse = new HttpResponseMessage();
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        HttpResponseMessage response = new HttpResponseMessage();
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var stringContent = new StringContent(JsonConvert.SerializeObject(common), Encoding.UTF8, "application/json");
                        response = httpClient.PostAsync(baseUrl, stringContent).Result;
                        if ((int)response.StatusCode == 200)
                        {
                            var contents = response.Content.ReadAsStringAsync();
                            result = (contents).Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        
        [HttpGet]
        public static async Task<string> get_method_data(string baseUrl, ParameterJSON common)
        {
            string result = "";
            string json = JsonConvert.SerializeObject(common);
            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    //httpResponse = await httpClient.PostAsync(baseUrl, data);                   
                    httpResponse = await httpClient.GetAsync(baseUrl + '/' + common.user_json);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        result = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                    if (result == "")
                    {
                        result = "401 Unauthorized";
                    }
                }
            }
            return result;
        }
        [HttpGet]
        public static async Task<string> get_method(string baseUrl)
        {
            string result = "";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    //httpResponse = await httpClient.PostAsync(baseUrl, data);                   
                    httpResponse = await httpClient.GetAsync(baseUrl);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        result = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                    if (result == "")
                    {
                        result = "401 Unauthorized";
                    }
                }
            }
            return result;
        }
        [HttpGet]
        public static string get_method_sync(string baseUrl)
        {
            string result = "";
            using (var client = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                client.Headers.Add("Content-Type:application/json");
                result = client.DownloadString(baseUrl);
            }
            return result;
        }
        [HttpPost]
        public static string post_method_sync(string baseUrl)
        {
            string result = "";
            using (var client = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
                client.Headers.Add("Content-Type:application/json");
                result = client.DownloadString(baseUrl);
            }
            return result;
        }

        [HttpDelete]
        public static async Task<string> delete_method(string baseUrl)
        {
            string result = "";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //httpResponse = await httpClient.PostAsync(baseUrl, data);
                    httpResponse = await httpClient.DeleteAsync(baseUrl);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        result = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                    if (result == "")
                    {
                        result = "401 Unauthorized";
                    }
                }
            }
            return result;
        }
        
        string strencodebase64 = "";
        public IDictionary<string, string> json_display(string strJson, string[] strArray)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(strJson);
            strencodebase64 = System.Convert.ToBase64String(plainTextBytes);
            JsonHandling objJ = new JsonHandling(strencodebase64);
            objJ.DecodeBase64Data();
            //DataTable dt = dtconversion.JsonStringToDataTable(strJson);
            //objJ.getJSONPropertiesFromString();
            Dictionary<string, string> dtarray = getJSONPropertiesFromString(strencodebase64);
            //Dictionary<string, string> PropertiesValues = objJ.getData(strArray);
            return dtarray;
        }
        public Dictionary<string, string> getJSONPropertiesFromString(string strjson)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                JArray a = JArray.Parse(strjson);
                foreach (JObject o in a.Children<JObject>())
                {
                    string param_name = "";
                    string param_value = "";
                    foreach (JProperty p in o.Properties())
                    {
                        param_name = p.Name.ToString();
                        param_value = p.Value.ToString();
                        dict.Add(param_name, param_value);
                    }
                }
            }
            catch (Exception)
            {
            }
            return dict;
        }


    }
}

