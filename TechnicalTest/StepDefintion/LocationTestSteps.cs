using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TechnicalTest
{
    [Binding]
    public class LocationTestSteps
    {
        private readonly LocationClient _locationClient;
        public LocationTestSteps(LocationClient locationClient)
        {
            _locationClient = locationClient;
        }

        [Given(@"I make a request to get location information (.*),(.*)")]
        public void GivenIMakeARequestToGetLocationInformation(string countryCode, string postCode)
        {
            _locationClient.GetLocationInformation(countryCode,postCode);
        }
        
        [Then(@"I verify the request status (.*)")]
        public void ThenTheRequestShouldBeSuccessful(string isSuccessful)
        {
            _locationClient.VerifyRequestStatus(isSuccessful);
        }
    }
}
