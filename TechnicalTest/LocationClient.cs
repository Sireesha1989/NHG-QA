using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TechnicalTest.Service;

namespace TechnicalTest
{
    public class LocationClient
    {
        private readonly RestService _resrService;
        private readonly ConfigurationProvider _configurationProvider;
        private RestResponse _response;

        public LocationClient(RestService restService, ConfigurationProvider configurationProvider)
        {
            _resrService = restService;
            _configurationProvider = configurationProvider;
        }

        public void GetLocationInformation(string countryCode, string postCode)
        {
            var url = _configurationProvider.GetUrl();

            var resource = $"{countryCode}/{postCode}";
            var restClient = new RestClient(url);
            var request = new RestRequest(resource, Method.Get);
            _response = restClient.Execute(request);
        }

        public void VerifyRequestStatus(string isSuccessful)
        {
            if (_response != null)
            {
                if (_response.IsSuccessStatusCode)
                {
                    Assert.AreEqual(isSuccessful, (_response.IsSuccessful).ToString());
                    Console.WriteLine("Request was successful.");
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {_response.StatusCode}");
                }
            }
            else
            {
                Console.WriteLine("No response received.");
            }
        }
    }
}

