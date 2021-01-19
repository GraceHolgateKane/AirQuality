using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using RestSharp;
using AirQualityPage.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace AirQualityPage.Controllers
{
    public class OpenAQ : Controller
    {

        public ActionResult Landing()
        {
            ViewBag.Message = "Manchester";
            IEnumerable<MeasurmentResult> value = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openaq.org/v1/");
                var responseTask = client.GetAsync("latest?city=Manchester");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResponseHolder<MeasurmentResult>>();
                    readTask.Wait();

                    value = readTask.Result.results;
                }
                else
                {
                    value = Enumerable.Empty<MeasurmentResult>();
                    ModelState.AddModelError(string.Empty, "Server Error: Please try again later");
                }
            }
            return View(value);

        }
        public ActionResult City(string code)
        {

            IEnumerable<AirQualityCities> cities = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openaq.org/v1/");
                    var responseTask = client.GetAsync("cities?country="+ code);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResponseHolder<AirQualityCities>>();
                    readTask.Wait();

                    cities = removeBlankCity(readTask.Result.results);
                }
                else
                {
                    cities = Enumerable.Empty<AirQualityCities>();
                    ModelState.AddModelError(string.Empty, "Server Error: Please try again later");
                }
            }
                return View(cities);
        }

        public ActionResult Country()
        {
            List<AirQualityCountry> countries = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openaq.org/v1/");
                var responseTask = client.GetAsync("countries?limit=110");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResponseHolder<AirQualityCountry>>();
                    readTask.Wait();
                    
                    countries = removeBlankContry(readTask.Result.results);

                }
                else
                {
                    countries = new List<AirQualityCountry>();
                    ModelState.AddModelError(string.Empty, "Server Error: Please try again later");
                }
            }
            return View(countries);
        }

        public List<AirQualityCountry> removeBlankContry(List<AirQualityCountry> airQualityCountries)
        {
            List<AirQualityCountry> countries = new List<AirQualityCountry>();
            foreach( var item in airQualityCountries)
            {
                if(item.name != null && item.name != "")
                {
                    countries.Add(item);
                }
            }

            return countries;
        }

        public List<AirQualityCities> removeBlankCity(List<AirQualityCities> airQualityCities)
        {
            List<AirQualityCities> cities = new List<AirQualityCities>();
            foreach (var item in airQualityCities)
            {
                if (item.name != null && item.name != "unused")
                {
                    cities.Add(item);
                }
            }

            return cities;
        }

        public ActionResult MeasurmentByCity(string code)
        {
            ViewBag.Message = code;
            IEnumerable<MeasurmentResult> value = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openaq.org/v1/");
                var responseTask = client.GetAsync("latest?city=" + code);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ResponseHolder<MeasurmentResult>>();
                    readTask.Wait();

                    value = readTask.Result.results;
                }
                else
                {
                    value = Enumerable.Empty<MeasurmentResult>();
                    ModelState.AddModelError(string.Empty, "Server Error: Please try again later");
                }
            }
            return View(value);

        }

    }
}

