using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace REST_Client
{
    class LCBOClient
    {
        public class Product
        {
            public String id;
            public String name;
            public String primary_category;
        }

        public class Store
        {
            public String id;
            public String name;
            public String address_line_1;
        }

        public LCBOClient(String endPoint = @"http://lcboapi.com")
        {
            this.endPoint = endPoint;
        }

        public List<Store> GetStores()
        {
            List<Store> stores = new List<Store>();

            try
            {
                var client = new RestClient(this.endPoint);
                var request = new RestRequest("/stores", Method.GET);

                var response = client.Execute(request);
                if (!response.IsSuccessful)
                    throw new Exception("Unable to Reach API");

                dynamic jsonResult = JsonConvert.DeserializeObject(response.Content);
                foreach (var store in jsonResult.result)
                {
                    Store storeObj = JsonConvert.DeserializeObject<Store>(store.ToString());
                    stores.Add(storeObj);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return stores;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                var client = new RestClient(this.endPoint);

                var request = new RestRequest("/products", Method.GET);

                var response = client.Execute(request);

                if (!response.IsSuccessful)
                    throw new Exception("Unable to Reach API");

                dynamic jsonResult = JsonConvert.DeserializeObject(response.Content);

                foreach (var item in jsonResult.result)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(item.ToString());
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return products;
        }

        public List<Product> SearchProducts(List<string> filters)
        {
            List<Product> products = new List<Product>();

            try
            {
                var client = new RestClient(this.endPoint);

                var request = new RestRequest("/products", Method.GET);

                string queryFilter = string.Join("+", filters);
                request.AddParameter("q", queryFilter); // adds to POST or URL querystring based on Method
                var response = client.Execute(request);

                if (!response.IsSuccessful)
                    throw new Exception("Unable to Reach API");

                dynamic jsonResult = JsonConvert.DeserializeObject(response.Content);

                foreach (var item in jsonResult.result)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(item.ToString());
                    products.Add(product);
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return products;
        }

        private String endPoint;

    }
}
