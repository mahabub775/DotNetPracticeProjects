
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Dynamic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BasicPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicPracticeController
    {


        [HttpGet(Name = "Get")]
        public string Get()
        {
            int nReturn = 0;


            // Replace "https://api.example.com" with the actual base URL of your REST API
            //https://jsonmock.hackerrank.com/api/weather?name=Dallas
            string apiUrl = "https://jsonmock.hackerrank.com/api/weather";

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {

         
                // Set the base address of the API
                client.BaseAddress = new Uri(apiUrl);

                try
                {
                    // Make a GET request to the API
                    HttpResponseMessage response = client.GetAsync("?name=Dallas").Result;

                    // Check if the request was successful (status code 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the content of the response
                        string result = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(result);



                        //dynamic person = JsonConvert.DeserializeObject<dynamic>(result);
                        weatherOb weatherdata = JsonSerializer.Deserialize<weatherOb>(result);
                        //dynamic cityData = person.data;
                        List<citydata> ocitydatas = weatherdata.data;

                        Console.WriteLine(ocitydatas[0].weather);
                        string []ntempreature = ocitydatas[0].weather.Split("degree");
                         nReturn = Convert.ToInt32(ntempreature[0]);
                        
                        Console.WriteLine(nReturn);
                        //Console.WriteLine(cityData);
                    }
                    else
                    {
                        // Print the status code if the request was not successful
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }



            return  nReturn.ToString() ;
        }

    }
    class weatherOb
    {
        //{"page":1,"per_page":10,"total":1,"total_pages":1,"data":[{"name":"Dallas","weather":"12 degree","status":["Wind: 2Kmph","Humidity: 5%"]}]}
        public int page { get; set; }
        public List<citydata> data { get; set; }
    }
    class citydata
    {
        //"name":"Dallas","weather":"12 degree","status":["Wind: 2Kmph","Humidity: 5%"
        public string name { get; set; }    
        public string weather { get; set; }
        public string[] status { get; set; }

    }
}
