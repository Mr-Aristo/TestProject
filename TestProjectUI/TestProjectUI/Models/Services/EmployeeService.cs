using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Windows;
using System.Net;

namespace TestProjectUI.Models.Services
{
    public class EmployeeService
    {
        public static readonly String conURL = "https://localhost:7129/api/Employee";

        public async void CreateEmployee(EmployeeModel md)
        {

            EmployeeModel val = new EmployeeModel
            {

                EmployeeName = md.EmployeeName,
                EmployeeDescription = md.EmployeeDescription
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(conURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();


                string message = string.Empty;
                try
                {
                    HttpResponseMessage response =
                        await client.PostAsJsonAsync($"/{conURL}", val);
                    response.EnsureSuccessStatusCode();

                    message = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Value getted");
                    }
                    else
                    {
                        MessageBox.Show("failed");
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }

            }
        }





        public static Task<HttpResponseMessage> GetCall()
        {

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = $"{conURL}/GetEmployee";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(apiUrl);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public static Task<HttpResponseMessage> PostCall<T>(T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = $"/{conURL}/";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static Task<HttpResponseMessage> PutCall<T>(T model) where T : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = $"/{conURL}/UpdateEmployee/";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PutAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Task<HttpResponseMessage> DeleteCall(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = $"/{conURL}/DeleteEmployee"+ url;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync(apiUrl);
                    response.Wait();
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
