using Newtonsoft.Json;
using RestSharp;
using System;

namespace REST_Client
{
    class AzureFunctionsClient
    {
        public AzureFunctionsClient(String endPoint = @"http://localhost:7071")
        {
            this.endPoint = endPoint;
        }

        public String RemoveVowels(string input)
        {
            try
            {
                var client = new RestClient(this.endPoint);

                var request = new RestRequest("api/RemoveVowels", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(JsonConvert.SerializeObject(input));

                var response = client.Execute(request);

                if (!response.IsSuccessful)
                    throw new Exception("Unable to Reach API");

                return JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private String endPoint;

    }
}
