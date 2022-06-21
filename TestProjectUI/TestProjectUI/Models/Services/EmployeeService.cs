using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Windows;

namespace TestProjectUI.Models.Services
{
    public class EmployeeService
    {
        public static readonly String conURL = "https://localhost:7129/api/Employee";



        //static async Task<Uri> CreateEmployee(EmployeeModel employee)
        //{

        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/CreateEmployee", employee);
        //    response.EnsureSuccessStatusCode();

        //    return response.Headers.Location;
        //}

        //static async Task RunAsync()
        //{
        //    client.BaseAddress = new Uri("https://localhost:7129/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //    EmployeeModel employee = new EmployeeModel
        //    {

        //        EmployeeName = "wpf",
        //        EmployeeDescription = "from wpf"
        //    };
        //    await CreateEmployee(employee);
        //}



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

        public async void GetAllEmployee()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{conURL}/GetEmployee");

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Value getted");
                    }
                    else
                    {
                        MessageBox.Show("failed");
                    }

                    //deserialization
                    List<EmployeeModel> ls =
                        await response.Content.ReadAsAsync<List<EmployeeModel>>();
                  

                    GetAll(ls);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "May server not running");
                }
            }


        }
        public IList<EmployeeModel> GetAll(IList<EmployeeModel> ls)
        {
            return ls; 

        }

        public async void EmployeeUpdate(EmployeeModel employee)
        {
            var val = new EmployeeModel
            {
                EmployeeName = employee.EmployeeName,
                EmployeeDescription = employee.EmployeeDescription,
            };

            using (HttpClient client = new HttpClient())
            {


                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{conURL}/{employee.EmployeeID}", val);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Value putted");
                    }
                    else
                    {
                        MessageBox.Show("failed");
                    }
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "May server not running");
                }
            }
        }




    }
}
