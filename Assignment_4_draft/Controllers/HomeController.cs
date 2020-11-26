using Assignment_4_draft.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Assignment_4_draft.Controllers
{
  public class HomeController : Controller
  {
    HttpClient httpClient;

    static string BASE_URL = "https://developer.nrel.gov/api/alt-fuel-stations/v1.json?fuel_type=E85";
    static string API_KEY = "aPSzfmUw75qcrrEgVxsAS0bpJYLFIkB8snXYcUzR"; //Add your API key here inside ""

    // Obtaining the API key is easy. The same key should be usable across the entire
    // data.gov developer network, i.e. all data sources on data.gov.
    // https://www.nps.gov/subjects/developer/get-started.htm

    public IActionResult Index()
    {
      httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
      httpClient.DefaultRequestHeaders.Accept.Add(
          new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

      string NATIONAL_PARK_API_PATH = BASE_URL + "/stations?limit=10";
      string parksData = "";

      Stations record = null;

      httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

      try
      {
        HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
          parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        if (!parksData.Equals(""))
        {
          // JsonConvert is part of the NewtonSoft.Json Nuget package
          record = JsonConvert.DeserializeObject<Stations>(parksData);
        }
      }
      catch (Exception e)
      {
        // This is a useful place to insert a breakpoint and observe the error message
        Console.WriteLine(e.Message);
      }

      return View(record);
    }
  }
}